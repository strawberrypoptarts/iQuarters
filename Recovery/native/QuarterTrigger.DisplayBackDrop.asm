
/Users/tomato/Documents/Codex/iQuarters/Recovery/native/iquarters-armv7:	file format mach-o arm

Disassembly of section __TEXT,__text:

0000cacc <start>:
  251150: e1a0c00d     	mov	r12, sp
  251154: e92d4080     	push	{r7, lr}
  251158: e1a0700d     	mov	r7, sp
  25115c: e92d5d00     	push	{r8, r10, r11, r12, lr}
  251160: e24dd00c     	sub	sp, sp, #12
  251164: e1a0b00d     	mov	r11, sp
  251168: e5cb0000     	strb	r0, [r11]
  25116c: e59f0000     	ldr	r0, [pc]                @ 0x251174 <start+0x2446a8>
  251170: ea000000     	b	0x251178 <start+0x2446ac> @ imm = #0x0
  251174: 004ffe4c     	subeq	pc, pc, r12, asr #28
  251178: e79f0000     	ldr	r0, [pc, r0]
  25117c: eb010217     	bl	0x2919e0 <start+0x284f14> @ imm = #0x4085c // UnityEngine.GameObject UnityEngine.GameObject::Find(System.String)
  251180: e1a0a000     	mov	r10, r0
  251184: eb010141     	bl	0x291690 <start+0x284bc4> @ imm = #0x40504 // System.Boolean UnityEngine.Object::op_Implicit(UnityEngine.Object)
  251188: e3500000     	cmp	r0, #0
  25118c: 0a000006     	beq	0x2511ac <start+0x2446e0> @ imm = #0x18
  251190: e1a0000a     	mov	r0, r10
  251194: e59ae000     	ldr	lr, [r10]
  251198: eb010214     	bl	0x2919f0 <start+0x284f24> @ imm = #0x40850 // UnityEngine.Renderer UnityEngine.GameObject::get_renderer()
  25119c: e1a02000     	mov	r2, r0
  2511a0: e5db1000     	ldrb	r1, [r11]
  2511a4: e592e000     	ldr	lr, [r2]
  2511a8: eb0101d8     	bl	0x291910 <start+0x284e44> @ imm = #0x40760 // System.Void UnityEngine.Renderer::set_enabled(System.Boolean)
  2511ac: e28bd00c     	add	sp, r11, #12
  2511b0: e8bd0d00     	pop	{r8, r10, r11}
  2511b4: e59d7008     	ldr	r7, [sp, #0x8]
  2511b8: e89da000     	ldm	sp, {sp, pc}
