"""Convert base mip of legacy textures to RGBA PNG; source mip data stays in IPA."""
from pathlib import Path
import json,struct,zlib,sys
sys.path.insert(0,str(Path(__file__).parent/'vendor'))
import texture2ddecoder
root=Path(__file__).resolve().parents[1];out=root/'converted/textures';out.mkdir(parents=True,exist_ok=True)
def chunk(kind,data):return struct.pack('>I',len(data))+kind+data+struct.pack('>I',zlib.crc32(kind+data)&0xffffffff)
def png(w,h,rgba):
    rows=b''.join(b'\0'+rgba[y*w*4:(y+1)*w*4] for y in range(h-1,-1,-1))
    return b'\x89PNG\r\n\x1a\n'+chunk(b'IHDR',struct.pack('>IIBBBBB',w,h,8,6,0,0,0))+chunk(b'IDAT',zlib.compress(rows))+chunk(b'IEND',b'')
manifest=[]
for archive in ('sharedassets0.assets','sharedassets1.assets'):
    data=(root/'extracted/Payload/iQuarters.app/Data'/archive).read_bytes();catalog=json.loads((root/'catalog'/(archive+'.json')).read_text())
    for obj in catalog['objects']:
        if obj['classId']!=28:continue
        p=obj['offset'];n=struct.unpack_from('<i',data,p)[0];name=data[p+4:p+4+n].decode();p=(p+4+n+3)&~3
        header=struct.unpack_from('<12i',data,p);w,h,total,fmt=header[:4];length=header[11];raw=data[p+48:p+48+length]
        if len(raw)!=length or ((p+48+length+3)&~3)!=obj['offset']+obj['size']:raise ValueError('Texture boundary mismatch')
        pixels=w*h
        if fmt in (32,33):
            bgra=texture2ddecoder.decode_pvrtc(raw,w,h,False)
            rgba=bytearray(bgra)
            rgba[0::4]=bgra[2::4];rgba[2::4]=bgra[0::4]
            if fmt==32:rgba[3::4]=b'\xff'*pixels
        elif fmt==5:rgba=b''.join(bytes((raw[i+1],raw[i+2],raw[i+3],raw[i])) for i in range(0,pixels*4,4))
        elif fmt==3:rgba=b''.join(raw[i:i+3]+b'\xff' for i in range(0,pixels*3,3))
        elif fmt==1:rgba=b''.join(bytes((255,255,255,a)) for a in raw[:pixels])
        elif fmt==2:
            rgba=bytearray()
            for (v,) in struct.iter_unpack('<H',raw[:pixels*2]):rgba.extend((((v>>8)&15)*17,((v>>4)&15)*17,(v&15)*17,((v>>12)&15)*17))
        else:raise ValueError('Unsupported texture format '+str(fmt))
        if len(rgba)!=pixels*4:raise ValueError('Decoded dimensions mismatch')
        filename=archive+'-'+str(obj['id'])+'.png';(out/filename).write_bytes(png(w,h,rgba))
        manifest.append({'source':archive,'pathId':obj['id'],'name':name,'width':w,'height':h,'format':fmt,'file':filename})
(out/'manifest.json').write_text(json.dumps(manifest,indent=2));print('Converted',len(manifest),'textures; exact source boundaries and decoded dimensions verified')
