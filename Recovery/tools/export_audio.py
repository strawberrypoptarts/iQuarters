"""Export observed legacy raw PCM audio; retain unknown serialized trailer separately.
PCM interpretation is supported by payload sizes matching duration * 11025 * 2.
"""
from pathlib import Path
import json,struct,wave
root=Path(__file__).resolve().parents[1];out=root/'converted/audio';out.mkdir(parents=True,exist_ok=True);manifest=[]
for archive in ('sharedassets0.assets','sharedassets1.assets'):
 data=(root/'extracted/Payload/iQuarters.app/Data'/archive).read_bytes()
 for obj in json.loads((root/'catalog'/(archive+'.json')).read_text())['objects']:
  if obj['classId']!=83:continue
  p=obj['offset'];n=struct.unpack_from('<i',data,p)[0];name=data[p+4:p+4+n].decode();p=(p+4+n+3)&~3
  kind,duration,rate,decoded,unknown,length=struct.unpack_from('<ifiiii',data,p)
  if kind!=2 or decoded!=length or length%2 or abs(length/(rate*2)-duration)>0.001:raise ValueError('Unsupported audio layout')
  raw=data[p+24:p+24+length]
  if len(raw)!=length:raise ValueError('Truncated audio')
  stem=archive+'-'+str(obj['id'])
  with wave.open(str(out/(stem+'.wav')),'wb') as wav:
   wav.setnchannels(1);wav.setsampwidth(2);wav.setframerate(rate);wav.writeframes(raw)
  manifest.append({'source':archive,'pathId':obj['id'],'name':name,'file':stem+'.wav','duration':duration,'sampleRate':rate,'unparsedTailBytes':obj['offset']+obj['size']-(p+24+length)})
(out/'manifest.json').write_text(json.dumps(manifest,indent=2));print('Exported',len(manifest),'PCM clips; stored duration agrees within 1 ms for every clip')
