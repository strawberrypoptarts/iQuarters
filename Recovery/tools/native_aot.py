"""Read the original ARMv7 Mach-O and Mono AOT globals without executing it."""
from pathlib import Path
import struct,json
root=Path(__file__).resolve().parents[2]
raw=(root/'Recovery/extracted/Payload/iQuarters.app/iQuarters').read_bytes()
for i in range(struct.unpack_from('>I',raw,4)[0]):
 cpu,sub,offset,length,align=struct.unpack_from('>IIIII',raw,8+i*20)
 if sub==9:break
else:raise ValueError('ARMv7 missing')
data=raw[offset:offset+length];segments=[];p=28
for i in range(struct.unpack_from('<I',data,16)[0]):
 cmd,size=struct.unpack_from('<II',data,p)
 if cmd==1:
  name,addr,vsize,fo,fs=struct.unpack_from('<16sIIII',data,p+8);segments.append((addr,fo,fs))
 p+=size
def read(addr,n):
 for va,fo,size in segments:
  if va<=addr<va+size:return data[fo+addr-va:fo+addr-va+n]
 raise ValueError(hex(addr))
def word(addr):return struct.unpack('<I',read(addr,4))[0]
def string(addr):return read(addr,512).split(b'\0')[0].decode()
globals={};table=word(0x751d20)
for i in range(100):
 name=word(table+i*8)
 if not name:break
 globals[string(name)]=word(table+i*8+4)
if __name__=='__main__':
 out=root/'Recovery/native';out.mkdir(exist_ok=True)
 (out/'aot-globals.json').write_text(json.dumps({k:hex(v) for k,v in globals.items()},indent=2))
 (out/'iquarters-armv7').write_bytes(data)
 print(json.dumps({k:hex(v) for k,v in globals.items()},indent=2))
