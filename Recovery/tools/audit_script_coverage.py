"""Inventory every supplied script, actual scene attachments, references and port coverage.
This is a coverage ledger, not an assertion of semantic/native equivalence.
"""
from pathlib import Path
import json,re,struct,hashlib
root=Path(__file__).resolve().parents[2];recovery=root/'Recovery'
paths=sorted((root/'Assets/Scripts').rglob('*.cs'));sources={p.stem:p.read_text() for p in paths}
scriptids={o['id']:o.get('candidateName') for o in json.loads((recovery/'catalog/sharedassets0.assets.json').read_text())['objects'] if o['classId']==115}
attachments={}
for scene in ('mainData','level0'):
 data=(recovery/f'extracted/Payload/iQuarters.app/Data/{scene}').read_bytes()
 for o in json.loads((recovery/f'catalog/{scene}.json').read_text())['objects']:
  if o['classId']!=114:continue
  file,id=struct.unpack_from('<ii',data,o['offset']+12)
  attachments.setdefault(scriptids[id],[]).append(f'{scene}:{o["id"]}')
notes={}
def group(names,note):
 for name in names.split():notes[name]=note
group('QuarterTrigger','Core physics/input/scoring ported; native flick/contact/stinger/replay selection checked. New solver is not original PhysX; complete native state-machine parity remains unverified.')
group('GameManagerScript PlayerInfoClass','C# session/player rules retained and tested; original platform input/preferences adapted to UIKit/storage.')
group('lightray','0.7 restores meshes, vertex alpha, additive tint, double-speed clip and Y minus 0.12 from native code; dynamic original side-by-side comparison pending.')
group('RoundComplete','Original clips and digit selection retained; 0.7 restores dim material alpha 0.5. UI 3D lighting still differs.')
group('ReplayCameraScript','0.7 uses all three recovered transforms/FOVs/damping; native round exclusions checked. Device comparison pending.')
group('RicochetExciter','Original holder/coin clips and scoring textures; 0.7 restores 45-frame score and 15–20-frame exit. Replay skipping remains incomplete.')
group('InGameAngleIcon','0.7 restores helper children and resting hold pose; root slide offset retained. Reminder animation/state detail remains incomplete.')
group('AngleAdjustScript','Angle input/range implemented; separate angle adjustment graphic not restored.')
group('CoinHolder','Score/coin HUD and original fly clips implemented; 0.7 restores visibility beneath helper parent. Holder transition state details not all reproduced.')
group('CoinsLeft','Counter works; original particle/coin-stack presentation incomplete.')
group('GlassScaleController','Original sampled pulse with 1.05 speed, 0.75 scale weighting; no device parity measurement.')
group('Streak PowerX PracticeGreatScore GameOver RoundIndicator UIPlayer','Original meshes/clips and event wiring implemented; complete frame-by-frame parity not verified.')
group('MainCameraScript ShadowQuarterScript LazySusanGlassShadow','Recovered follow/shadow values implemented; aspect adaptation is a deliberate modern-device change.')
group('LauncherScript LighterScript BirdScript','Recovered geometry, animation and reaction values loaded; replay uses recorded poses. Original engine simulation equivalence not guaranteed.')
group('AnnouncerScript CrowdScript','Recovered clips preloaded; 0.7 native stinger gate corrected. Audio mixing/device timing still unverified.')
group('ReplayController SaveReplayButtons','Current-shot automatic/manual replay implemented; six-slot persistent replay gallery/save workflow missing.')
group('SecretRound','Round content available; original secret intro/outro presentation not fully connected.')
group('IntroCamScript','Serialized camera preserved; original intro camera flow not restored.')
group('SpotlightScript spotdirScript','Original static lighting recovered; animated spotlight/rotation behavior not reproduced.')
group('PauseButtonScript PauseMenu Help ShotTypeHelper PracticeUI StatsScreen','Functional host UI/selected original clips; text, help, statistics and some transitions use host substitutes.')
group('HiScoreRoundScript HiScoreScript InGameHiScore Entry','Scores persisted through GameStorage; exact original presentation/preference format not retained.')
group('mainmenu Logo RoundHighScreen GameHighScreen GameOrRoundButtons BackClearButtons About AreYouSure','Menu assets/animations implemented in MainMenuController; selected text/dialogs use UIKit. Complete native branch parity not audited.')
group('ColliderInfoClass ColliderGameObjectClass','Data role replaced by CollisionShape/CollisionChain; core trajectory regression preserved.')
rows=[]
for p in paths:
 name=p.stem;source=sources[name]
 refs=[other for other,text in sources.items() if other!=name and re.search(r'\b'+re.escape(name)+r'\b',text)]
 methods=re.findall(r'^\s*(?:public|private|protected)\s+(?:static\s+)?[\w\[\]]+\s+(\w+)\s*\(',source,re.M)
 note=notes.get(name,'No component attached in either shipped scene. '+('Referenced by supplied scripts; reachability/native behavior not fully established.' if refs else 'No name reference in other supplied scripts; not activated by this port.'))
 if name=='AssemblyInfo':note='Assembly metadata; no gameplay behavior.'
 rows.append(dict(script=str(p.relative_to(root)),sha256=hashlib.sha256(p.read_bytes()).hexdigest(),attachments=attachments.get(name,[]),referencesFrom=refs,methods=methods,coverage=note,nativeDisassemblies=[str(x.relative_to(recovery)) for x in sorted((recovery/'native').glob(name+'.*.asm'))]))
(recovery/'script-coverage.json').write_text(json.dumps(rows,indent=2)+'\n')
lines=['# Script coverage ledger — 0.7.0','','All 84 supplied files are inventoried below with their actual attachments and port status. This is **not** a completed 1:1 certification: only the native routines identified in the evidence notes have been checked against the executable. Unattached scripts can still be referenced statically; the JSON ledger lists those references and every declared method.','','| Script | Scene components | Current coverage / remaining difference |','|---|---:|---|']
for row in rows:lines.append('| '+Path(row['script']).stem+' | '+str(len(row['attachments']))+' | '+row['coverage']+' |')
(recovery/'SCRIPT_COVERAGE_0.7.md').write_text('\n'.join(lines)+'\n')
print(len(rows),'scripts;',len(attachments),'attached script classes;',sum(map(len,attachments.values())),'components')
