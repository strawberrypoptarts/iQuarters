import Foundation
import AVFoundation
let paths=try FileManager.default.contentsOfDirectory(at:URL(fileURLWithPath:CommandLine.arguments[1]),includingPropertiesForKeys:nil).filter{$0.pathExtension=="wav"}.sorted{$0.path<$1.path}
let engine=AVAudioEngine(),players=(0..<4).map{_ in AVAudioPlayerNode()};for p in players{engine.attach(p)};let player=players[0]
var buffers=[AVAudioPCMBuffer]()
for path in paths{let file=try AVAudioFile(forReading:path);let b=AVAudioPCMBuffer(pcmFormat:file.processingFormat,frameCapacity:AVAudioFrameCount(file.length))!;try file.read(into:b);buffers.append(b)}
let format=buffers[0].format
precondition(buffers.allSatisfy{$0.format.sampleRate==format.sampleRate && $0.format.channelCount==format.channelCount})
for p in players{engine.connect(p,to:engine.mainMixerNode,format:format)}
try engine.enableManualRenderingMode(.offline,format:format,maximumFrameCount:512)
engine.prepare();try engine.start();for p in players{p.play()}
let output=AVAudioPCMBuffer(pcmFormat:format,frameCapacity:512)!
var audible=0,worst=0.0
for b in buffers{
 let start=CFAbsoluteTimeGetCurrent();player.scheduleBuffer(b,at:nil,options:.interrupts,completionHandler:nil);worst=max(worst,(CFAbsoluteTimeGetCurrent()-start)*1000)
 var peak:Float=0
 for _ in 0..<8{let status=try engine.renderOffline(512,to:output);precondition(status == .success);if let p=output.floatChannelData?[0]{for i in 0..<Int(output.frameLength){peak=max(peak,abs(p[i]))}}}
 if peak>0.00001{audible+=1}
}
engine.pause();try engine.start();player.play();player.scheduleBuffer(buffers[0],at:nil,options:.interrupts,completionHandler:nil);let resumed=try engine.renderOffline(512,to:output);precondition(resumed == .success)
precondition(audible==buffers.count)
for (i,p) in players.enumerated(){p.scheduleBuffer(buffers[i+3],at:nil,options:.interrupts,completionHandler:nil)}
let mixed=try engine.renderOffline(512,to:output);precondition(mixed == .success)

print("{\"buffers\":\(buffers.count),\"audibleBuffers\":\(audible),\"worstScheduleMilliseconds\":\(worst),\"pauseResume\":true,\"simultaneousChannels\":4,\"test\":\"macOS offline AVAudioEngine, not iOS device playback\"}")
engine.stop()
