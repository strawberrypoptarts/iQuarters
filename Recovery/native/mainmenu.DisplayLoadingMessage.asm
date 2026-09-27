
/Users/tomato/Documents/Codex/iQuarters/Recovery/native/iquarters-armv7:	file format mach-o arm

Disassembly of section __TEXT,__text:

0000cacc <start>:
  240fa8: e1a0c00d     	mov	r12, sp
  240fac: e92d4080     	push	{r7, lr}
  240fb0: e1a0700d     	mov	r7, sp
  240fb4: e92d5900     	push	{r8, r11, r12, lr}
  240fb8: e24dd038     	sub	sp, sp, #56
  240fbc: e1a0b00d     	mov	r11, sp
  240fc0: e58b0030     	str	r0, [r11, #0x30]
  240fc4: e59b0030     	ldr	r0, [r11, #0x30]
  240fc8: e5900040     	ldr	r0, [r0, #0x40]
  240fcc: eb0142a7     	bl	0x291a70 <start+0x284fa4> @ imm = #0x50a9c // System.Void UnityEngine.GUI::set_skin(UnityEngine.GUISkin)
  240fd0: e3a00006     	mov	r0, #6
  240fd4: ee000a10     	vmov	s0, r0
  240fd8: eeb80ac0     	vcvt.f32.s32	s0, s0
  240fdc: eeb75ac0     	vcvt.f64.f32	d5, s0
  240fe0: e3a00f78     	mov	r0, #120, #30
  240fe4: e3a01020     	mov	r1, #32
  240fe8: e0500001     	subs	r0, r0, r1
  240fec: 6b000044     	blvs	0x241104 <start+0x234638> @ imm = #0x110
  240ff0: ee000a10     	vmov	s0, r0
  240ff4: eeb80ac0     	vcvt.f32.s32	s0, s0
  240ff8: eeb74ac0     	vcvt.f64.f32	d4, s0
  240ffc: e3a00078     	mov	r0, #120
  241000: ee000a10     	vmov	s0, r0
  241004: eeb80ac0     	vcvt.f32.s32	s0, s0
  241008: eeb73ac0     	vcvt.f64.f32	d3, s0
  24100c: e3a00020     	mov	r0, #32
  241010: ee000a10     	vmov	s0, r0
  241014: eeb80ac0     	vcvt.f32.s32	s0, s0
  241018: eeb72ac0     	vcvt.f64.f32	d2, s0
  24101c: e3a00000     	mov	r0, #0
  241020: e58b0020     	str	r0, [r11, #0x20]
  241024: e3a00000     	mov	r0, #0
  241028: e58b0024     	str	r0, [r11, #0x24]
  24102c: e3a00000     	mov	r0, #0
  241030: e58b0028     	str	r0, [r11, #0x28]
  241034: e3a00000     	mov	r0, #0
  241038: e58b002c     	str	r0, [r11, #0x2c]
  24103c: e28b0020     	add	r0, r11, #32
  241040: eeb70bc5     	vcvt.f32.f64	s0, d5
  241044: ed0d0a02     	vstr	s0, [sp, #-8]
  241048: e51d1008     	ldr	r1, [sp, #-0x8]
  24104c: eeb70bc4     	vcvt.f32.f64	s0, d4
  241050: ed0d0a02     	vstr	s0, [sp, #-8]
  241054: e51d2008     	ldr	r2, [sp, #-0x8]
  241058: eeb70bc3     	vcvt.f32.f64	s0, d3
  24105c: ed0d0a02     	vstr	s0, [sp, #-8]
  241060: e51d3008     	ldr	r3, [sp, #-0x8]
  241064: eeb70bc2     	vcvt.f32.f64	s0, d2
  241068: ed8d0a00     	vstr	s0, [sp]
  24106c: eb014273     	bl	0x291a40 <start+0x284f74> @ imm = #0x509cc // System.Void UnityEngine.Rect::.ctor(System.Single,System.Single,System.Single,System.Single)
  241070: e59b0020     	ldr	r0, [r11, #0x20]
  241074: e58b0010     	str	r0, [r11, #0x10]
  241078: e59b0024     	ldr	r0, [r11, #0x24]
  24107c: e58b0014     	str	r0, [r11, #0x14]
  241080: e59b0028     	ldr	r0, [r11, #0x28]
  241084: e58b0018     	str	r0, [r11, #0x18]
  241088: e59b002c     	ldr	r0, [r11, #0x2c]
  24108c: e58b001c     	str	r0, [r11, #0x1c]
  241090: eb000ade     	bl	0x243c10 <start+0x237144> @ imm = #0x2b78
  241094: e3500000     	cmp	r0, #0
  241098: 0a00000b     	beq	0x2410cc <start+0x234600> @ imm = #0x2c
  24109c: e59b0030     	ldr	r0, [r11, #0x30]
  2410a0: e5900044     	ldr	r0, [r0, #0x44]
  2410a4: eb014271     	bl	0x291a70 <start+0x284fa4> @ imm = #0x509c4 // System.Void UnityEngine.GUI::set_skin(UnityEngine.GUISkin)
  2410a8: e28b0010     	add	r0, r11, #16
  2410ac: e59b1010     	ldr	r1, [r11, #0x10]
  2410b0: e59b2014     	ldr	r2, [r11, #0x14]
  2410b4: e59b3018     	ldr	r3, [r11, #0x18]
  2410b8: e59bc01c     	ldr	r12, [r11, #0x1c]
  2410bc: e58dc000     	str	r12, [sp]
  2410c0: e3a0c001     	mov	r12, #1
  2410c4: e58dc004     	str	r12, [sp, #0x4]
  2410c8: eb014260     	bl	0x291a50 <start+0x284f84> @ imm = #0x50980 // UnityEngine.Rect GameManagerScript::GetiPadRect(UnityEngine.Rect,System.Boolean)
  2410cc: e59fc000     	ldr	r12, [pc]               @ 0x2410d4 <start+0x234608>
  2410d0: ea000000     	b	0x2410d8 <start+0x23460c> @ imm = #0x0
  2410d4: 0050fc94     	<unknown>
  2410d8: e79fc00c     	ldr	r12, [pc, r12]
  2410dc: e59b0010     	ldr	r0, [r11, #0x10]
  2410e0: e59b1014     	ldr	r1, [r11, #0x14]
  2410e4: e59b2018     	ldr	r2, [r11, #0x18]
  2410e8: e59b301c     	ldr	r3, [r11, #0x1c]
  2410ec: e58dc000     	str	r12, [sp]
  2410f0: eb01425a     	bl	0x291a60 <start+0x284f94> @ imm = #0x50968 // System.Void UnityEngine.GUI::Label(UnityEngine.Rect,System.String)
  2410f4: e28bd038     	add	sp, r11, #56
  2410f8: e8bd0900     	pop	{r8, r11}
  2410fc: e59d7008     	ldr	r7, [sp, #0x8]
  241100: e89da000     	ldm	sp, {sp, pc}
  241104: e1a0100e     	mov	r1, lr
  241108: e59f0000     	ldr	r0, [pc]                @ 0x241110 <start+0x234644>
  24110c: eb01410b     	bl	0x291540 <start+0x284a74> @ imm = #0x5042c
  241110: 020000fd     	andeq	r0, r0, #253
