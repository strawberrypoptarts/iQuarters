
/Users/tomato/Documents/Codex/iQuarters/Recovery/native/iquarters-armv7:	file format mach-o arm

Disassembly of section __TEXT,__text:

0000cacc <start>:
  237678: e1a0c00d     	mov	r12, sp
  23767c: e92d4080     	push	{r7, lr}
  237680: e1a0700d     	mov	r7, sp
  237684: e92d5d70     	push	{r4, r5, r6, r8, r10, r11, r12, lr}
  237688: e24dd030     	sub	sp, sp, #48
  23768c: e1a0b00d     	mov	r11, sp
  237690: e58b0020     	str	r0, [r11, #0x20]
  237694: e1a0a001     	mov	r10, r1
  237698: e3a00000     	mov	r0, #0
  23769c: e58b0000     	str	r0, [r11]
  2376a0: e3a00000     	mov	r0, #0
  2376a4: e58b0004     	str	r0, [r11, #0x4]
  2376a8: e3a00000     	mov	r0, #0
  2376ac: e58b0008     	str	r0, [r11, #0x8]
  2376b0: e3a00000     	mov	r0, #0
  2376b4: e58b000c     	str	r0, [r11, #0xc]
  2376b8: e1a0000a     	mov	r0, r10
  2376bc: e59ae000     	ldr	lr, [r10]
  2376c0: eb01686a     	bl	0x291870 <start+0x284da4> @ imm = #0x5a1a8 // UnityEngine.Mesh UnityEngine.MeshFilter::get_mesh()
  2376c4: e1a0a000     	mov	r10, r0
  2376c8: e1a0100a     	mov	r1, r10
  2376cc: e1a00001     	mov	r0, r1
  2376d0: e591e000     	ldr	lr, [r1]
  2376d4: eb016869     	bl	0x291880 <start+0x284db4> @ imm = #0x5a1a4 // UnityEngine.Vector3[] UnityEngine.Mesh::get_vertices()
  2376d8: e1a06000     	mov	r6, r0
  2376dc: e590100c     	ldr	r1, [r0, #0xc]
  2376e0: e59f0000     	ldr	r0, [pc]                @ 0x2376e8 <start+0x22ac1c>
  2376e4: ea000000     	b	0x2376ec <start+0x22ac20> @ imm = #0x0
  2376e8: 00519404     	subseq	r9, r1, r4, lsl #8
  2376ec: e79f0000     	ldr	r0, [pc, r0]
  2376f0: eb016866     	bl	0x291890 <start+0x284dc4> @ imm = #0x5a198
  2376f4: e1a05000     	mov	r5, r0
  2376f8: e3a04000     	mov	r4, #0
  2376fc: ea000045     	b	0x237818 <start+0x22ad4c> @ imm = #0x114
  237700: e1a0000b     	mov	r0, r11
  237704: eb016865     	bl	0x2918a0 <start+0x284dd4> @ imm = #0x5a194 // UnityEngine.Color UnityEngine.Color::get_white()
  237708: e3a00001     	mov	r0, #1
  23770c: ee000a10     	vmov	s0, r0
  237710: eeb80ac0     	vcvt.f32.s32	s0, s0
  237714: eeb72ac0     	vcvt.f64.f32	d2, s0
  237718: eeb70bc2     	vcvt.f32.f64	s0, d2
  23771c: ed8b0a03     	vstr	s0, [r11, #12]
  237720: e1a0000a     	mov	r0, r10
  237724: e59ae000     	ldr	lr, [r10]
  237728: eb016860     	bl	0x2918b0 <start+0x284de4> @ imm = #0x5a180 // UnityEngine.Color[] UnityEngine.Mesh::get_colors()
  23772c: e1a01000     	mov	r1, r0
  237730: e58b1028     	str	r1, [r11, #0x28]
  237734: e1a01004     	mov	r1, r4
  237738: eb01679c     	bl	0x2915b0 <start+0x284ae4> @ imm = #0x59e70
  23773c: e1a01000     	mov	r1, r0
  237740: e59b0028     	ldr	r0, [r11, #0x28]
  237744: e590200c     	ldr	r2, [r0, #0xc]
  237748: e1520001     	cmp	r2, r1
  23774c: 9b000040     	blls	0x237854 <start+0x22ad88> @ imm = #0x100
  237750: e1a01201     	lsl	r1, r1, #4
  237754: e0800001     	add	r0, r0, r1
  237758: e2800010     	add	r0, r0, #16
  23775c: ed900a01     	vldr	s0, [r0, #4]
  237760: eeb72ac0     	vcvt.f64.f32	d2, s0
  237764: e3a00000     	mov	r0, #0
  237768: ee000a10     	vmov	s0, r0
  23776c: eeb80ac0     	vcvt.f32.s32	s0, s0
  237770: eeb73ac0     	vcvt.f64.f32	d3, s0
  237774: eeb43b42     	vcmp.f64	d3, d2
  237778: eef1fa10     	vmrs	APSR_nzcv, fpscr
  23777c: e3a00000     	mov	r0, #0
  237780: 43a00001     	movmi	r0, #1
  237784: e3500000     	cmp	r0, #0
  237788: 0a000005     	beq	0x2377a4 <start+0x22acd8> @ imm = #0x14
  23778c: e3a00000     	mov	r0, #0
  237790: ee000a10     	vmov	s0, r0
  237794: eeb80ac0     	vcvt.f32.s32	s0, s0
  237798: eeb72ac0     	vcvt.f64.f32	d2, s0
  23779c: eeb70bc2     	vcvt.f32.f64	s0, d2
  2377a0: ed8b0a03     	vstr	s0, [r11, #12]
  2377a4: e1a00005     	mov	r0, r5
  2377a8: e1a01004     	mov	r1, r4
  2377ac: eb01677f     	bl	0x2915b0 <start+0x284ae4> @ imm = #0x59dfc
  2377b0: e595100c     	ldr	r1, [r5, #0xc]
  2377b4: e1510000     	cmp	r1, r0
  2377b8: 9b000025     	blls	0x237854 <start+0x22ad88> @ imm = #0x94
  2377bc: e1a00200     	lsl	r0, r0, #4
  2377c0: e0850000     	add	r0, r5, r0
  2377c4: e2800010     	add	r0, r0, #16
  2377c8: e59b1000     	ldr	r1, [r11]
  2377cc: e58b1010     	str	r1, [r11, #0x10]
  2377d0: e59b1004     	ldr	r1, [r11, #0x4]
  2377d4: e58b1014     	str	r1, [r11, #0x14]
  2377d8: e59b1008     	ldr	r1, [r11, #0x8]
  2377dc: e58b1018     	str	r1, [r11, #0x18]
  2377e0: e59b100c     	ldr	r1, [r11, #0xc]
  2377e4: e58b101c     	str	r1, [r11, #0x1c]
  2377e8: e59b1010     	ldr	r1, [r11, #0x10]
  2377ec: e5801000     	str	r1, [r0]
  2377f0: e59b1014     	ldr	r1, [r11, #0x14]
  2377f4: e5801004     	str	r1, [r0, #0x4]
  2377f8: e59b1018     	ldr	r1, [r11, #0x18]
  2377fc: e5801008     	str	r1, [r0, #0x8]
  237800: e59b101c     	ldr	r1, [r11, #0x1c]
  237804: e580100c     	str	r1, [r0, #0xc]
  237808: e3a00001     	mov	r0, #1
  23780c: e0940000     	adds	r0, r4, r0
  237810: 6b00000b     	blvs	0x237844 <start+0x22ad78> @ imm = #0x2c
  237814: e1a04000     	mov	r4, r0
  237818: e596000c     	ldr	r0, [r6, #0xc]
  23781c: e1540000     	cmp	r4, r0
  237820: baffffb6     	blt	0x237700 <start+0x22ac34> @ imm = #-0x128
  237824: e1a0000a     	mov	r0, r10
  237828: e1a01005     	mov	r1, r5
  23782c: e59ae000     	ldr	lr, [r10]
  237830: eb016822     	bl	0x2918c0 <start+0x284df4> @ imm = #0x5a088 // System.Void UnityEngine.Mesh::set_colors(UnityEngine.Color[])
  237834: e28bd030     	add	sp, r11, #48
  237838: e8bd0d70     	pop	{r4, r5, r6, r8, r10, r11}
  23783c: e59d7008     	ldr	r7, [sp, #0x8]
  237840: e89da000     	ldm	sp, {sp, pc}
  237844: e1a0100e     	mov	r1, lr
  237848: e59f0000     	ldr	r0, [pc]                @ 0x237850 <start+0x22ad84>
  23784c: eb01673b     	bl	0x291540 <start+0x284a74> @ imm = #0x59cec
  237850: 020000fd     	andeq	r0, r0, #253
  237854: e1a0100e     	mov	r1, lr
  237858: e59f0000     	ldr	r0, [pc]                @ 0x237860 <start+0x22ad94>
  23785c: eb016737     	bl	0x291540 <start+0x284a74> @ imm = #0x59cdc
  237860: 020000a7     	andeq	r0, r0, #167
