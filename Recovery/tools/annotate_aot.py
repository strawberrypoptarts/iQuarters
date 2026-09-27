"""Annotate original AOT call sites from preserved MethodDef tokens and PLT metadata.
Mono 2.6 aot-runtime.c: decode_value, decode_method_ref, code_offsets.
"""
import json,re,subprocess,sys
import native_aot as a
out=a.root/'Recovery/native'
methods=json.loads((out/'methods.json').read_text());unity=json.loads((out/'unity-methods.json').read_text())
lookup=[{m['rid']:m['signature'] for m in group} for group in [methods,unity]]
def value(p):
 b=a.read(p,1)[0];p+=1
 if b<128:return b,p
 n=1 if b<192 else 4 if b==255 else 3
 v=0 if b==255 else b&(63 if n==1 else 31)
 for x in a.read(p,n):v=v*256+x
 return v,p+n
calls={}
for addr in range(a.globals['plt'],a.globals['plt_end'],16):
 try:
  p=a.globals['got_info']+a.word(addr+12);kind,p=value(p)
  if kind!=3:continue
  token,p=value(p);idx=token>>24;rid=token&0xffffff
  if idx<len(lookup):calls[addr]=lookup[idx].get(rid,str(token))
 except ValueError:pass
for m in methods:
 if len(sys.argv)>1:
  if m['type']+'.'+m['name'] not in sys.argv[1:]:continue
 elif m['type']!='QuarterTrigger' or m['name'] not in ['FixedUpdate','fUpdate','.ctor','OnCollisionStay']:continue
 end=min(x['address'] for x in methods if x['address']>m['address'])
 asm=subprocess.check_output(['xcrun','llvm-objdump','-d','--mattr=+vfp3',f"--start-address={m['address']}",f'--stop-address={end}',str(out/'iquarters-armv7')],text=True)
 def annotate(line):
  match=re.search(r'\bbl\s+0x([0-9a-f]+)',line)
  return line+(' // '+calls[int(match[1],16)] if match and int(match[1],16) in calls else '')
 (out/f"{m['type']}.{m['name'].lstrip('.')}.asm").write_text('\n'.join(map(annotate,asm.splitlines()))+'\n')
print({hex(k):v for k,v in calls.items() if 0x292510<=k<=0x292560})
