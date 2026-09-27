
/Users/tomato/Documents/Codex/iQuarters/Recovery/native/iquarters-armv7:	file format mach-o arm

Disassembly of section __TEXT,__text:

0000cacc <start>:
  24e4d4: e1a0c00d     	mov	r12, sp
  24e4d8: e92d4080     	push	{r7, lr}
  24e4dc: e1a0700d     	mov	r7, sp
  24e4e0: e92d5d00     	push	{r8, r10, r11, r12, lr}
  24e4e4: e24ddf67     	sub	sp, sp, #412
  24e4e8: e1a0b00d     	mov	r11, sp
  24e4ec: e1a0a000     	mov	r10, r0
  24e4f0: e3a00000     	mov	r0, #0
  24e4f4: e58b001c     	str	r0, [r11, #0x1c]
  24e4f8: e3a00000     	mov	r0, #0
  24e4fc: e58b0020     	str	r0, [r11, #0x20]
  24e500: e3a00000     	mov	r0, #0
  24e504: e58b0024     	str	r0, [r11, #0x24]
  24e508: e3a00000     	mov	r0, #0
  24e50c: e58b0028     	str	r0, [r11, #0x28]
  24e510: e3a00000     	mov	r0, #0
  24e514: e58b002c     	str	r0, [r11, #0x2c]
  24e518: e3a00000     	mov	r0, #0
  24e51c: e58b0030     	str	r0, [r11, #0x30]
  24e520: e3a00000     	mov	r0, #0
  24e524: e58b0038     	str	r0, [r11, #0x38]
  24e528: e3a00000     	mov	r0, #0
  24e52c: e58b003c     	str	r0, [r11, #0x3c]
  24e530: e3a00000     	mov	r0, #0
  24e534: e58b0040     	str	r0, [r11, #0x40]
  24e538: e3a00000     	mov	r0, #0
  24e53c: e58b0048     	str	r0, [r11, #0x48]
  24e540: e3a00000     	mov	r0, #0
  24e544: e58b004c     	str	r0, [r11, #0x4c]
  24e548: e3a00000     	mov	r0, #0
  24e54c: e58b0050     	str	r0, [r11, #0x50]
  24e550: e3a00000     	mov	r0, #0
  24e554: e58b0054     	str	r0, [r11, #0x54]
  24e558: e3a00000     	mov	r0, #0
  24e55c: e58b005c     	str	r0, [r11, #0x5c]
  24e560: e3a00000     	mov	r0, #0
  24e564: e58b0060     	str	r0, [r11, #0x60]
  24e568: e3a00000     	mov	r0, #0
  24e56c: e58b0064     	str	r0, [r11, #0x64]
  24e570: e3a00000     	mov	r0, #0
  24e574: e58b006c     	str	r0, [r11, #0x6c]
  24e578: e3a00000     	mov	r0, #0
  24e57c: e58b0070     	str	r0, [r11, #0x70]
  24e580: e3a00000     	mov	r0, #0
  24e584: e58b0074     	str	r0, [r11, #0x74]
  24e588: e3a00000     	mov	r0, #0
  24e58c: e58b007c     	str	r0, [r11, #0x7c]
  24e590: e3a00000     	mov	r0, #0
  24e594: e58b0080     	str	r0, [r11, #0x80]
  24e598: e3a00000     	mov	r0, #0
  24e59c: e58b0084     	str	r0, [r11, #0x84]
  24e5a0: e3a00000     	mov	r0, #0
  24e5a4: e58b008c     	str	r0, [r11, #0x8c]
  24e5a8: e3a00000     	mov	r0, #0
  24e5ac: e58b0090     	str	r0, [r11, #0x90]
  24e5b0: e3a00000     	mov	r0, #0
  24e5b4: e58b0094     	str	r0, [r11, #0x94]
  24e5b8: e3a00000     	mov	r0, #0
  24e5bc: e58b009c     	str	r0, [r11, #0x9c]
  24e5c0: e3a00000     	mov	r0, #0
  24e5c4: e58b00a0     	str	r0, [r11, #0xa0]
  24e5c8: e3a00000     	mov	r0, #0
  24e5cc: e58b00a4     	str	r0, [r11, #0xa4]
  24e5d0: e3a00000     	mov	r0, #0
  24e5d4: e58b00ac     	str	r0, [r11, #0xac]
  24e5d8: e3a00000     	mov	r0, #0
  24e5dc: e58b00b0     	str	r0, [r11, #0xb0]
  24e5e0: e3a00000     	mov	r0, #0
  24e5e4: e58b00b4     	str	r0, [r11, #0xb4]
  24e5e8: e59a0010     	ldr	r0, [r10, #0x10]
  24e5ec: eb010c27     	bl	0x291690 <start+0x284bc4> @ imm = #0x4309c // System.Boolean UnityEngine.Object::op_Implicit(UnityEngine.Object)
  24e5f0: e3500000     	cmp	r0, #0
  24e5f4: 0a0001df     	beq	0x24ed78 <start+0x2422ac> @ imm = #0x77c
  24e5f8: e59f0000     	ldr	r0, [pc]                @ 0x24e600 <start+0x241b34>
  24e5fc: ea000000     	b	0x24e604 <start+0x241b38> @ imm = #0x0
  24e600: 005027d4     	ldrsbeq	r2, [r0], #-116
  24e604: e79f0000     	ldr	r0, [pc, r0]
  24e608: ed900a00     	vldr	s0, [r0]
  24e60c: eeb72ac0     	vcvt.f64.f32	d2, s0
  24e610: e59f0000     	ldr	r0, [pc]                @ 0x24e618 <start+0x241b4c>
  24e614: ea000000     	b	0x24e61c <start+0x241b50> @ imm = #0x0
  24e618: 005027b8     	ldrheq	r2, [r0], #-120
  24e61c: e79f0000     	ldr	r0, [pc, r0]
  24e620: ed900a00     	vldr	s0, [r0]
  24e624: eeb73ac0     	vcvt.f64.f32	d3, s0
  24e628: ee322b43     	vsub.f64	d2, d2, d3
  24e62c: e59f0000     	ldr	r0, [pc]                @ 0x24e634 <start+0x241b68>
  24e630: ea000000     	b	0x24e638 <start+0x241b6c> @ imm = #0x0
  24e634: 005028ac     	subseq	r2, r0, r12, lsr #17
  24e638: e79f0000     	ldr	r0, [pc, r0]
  24e63c: ed900a00     	vldr	s0, [r0]
  24e640: eeb73ac0     	vcvt.f64.f32	d3, s0
  24e644: e59f0000     	ldr	r0, [pc]                @ 0x24e64c <start+0x241b80>
  24e648: ea000000     	b	0x24e650 <start+0x241b84> @ imm = #0x0
  24e64c: 00502784     	subseq	r2, r0, r4, lsl #15
  24e650: e79f0000     	ldr	r0, [pc, r0]
  24e654: ed900a00     	vldr	s0, [r0]
  24e658: eeb74ac0     	vcvt.f64.f32	d4, s0
  24e65c: ee333b44     	vsub.f64	d3, d3, d4
  24e660: ee822b03     	vdiv.f64	d2, d2, d3
  24e664: eeb70bc2     	vcvt.f32.f64	s0, d2
  24e668: ed8b0a06     	vstr	s0, [r11, #24]
  24e66c: ed9a0a0b     	vldr	s0, [r10, #44]
  24e670: eeb72ac0     	vcvt.f64.f32	d2, s0
  24e674: ed9b0a06     	vldr	s0, [r11, #24]
  24e678: eeb73ac0     	vcvt.f64.f32	d3, s0
  24e67c: ed9a0a0b     	vldr	s0, [r10, #44]
  24e680: eeb74ac0     	vcvt.f64.f32	d4, s0
  24e684: ee333b44     	vsub.f64	d3, d3, d4
  24e688: ed9f4a00     	vldr	s8, [pc]                @ 0x24e690 <start+0x241bc4>
  24e68c: ea000000     	b	0x24e694 <start+0x241bc8> @ imm = #0x0
  24e690: 3e4ccccd     	cdplo	p12, #0x4, c12, c12, c13, #0x6
  24e694: eeb74ac4     	vcvt.f64.f32	d4, s8
  24e698: ee233b04     	vmul.f64	d3, d3, d4
  24e69c: ee322b03     	vadd.f64	d2, d2, d3
  24e6a0: eeb70bc2     	vcvt.f32.f64	s0, d2
  24e6a4: ed8a0a0b     	vstr	s0, [r10, #44]
  24e6a8: e3a00000     	mov	r0, #0
  24e6ac: e58b001c     	str	r0, [r11, #0x1c]
  24e6b0: e3a00000     	mov	r0, #0
  24e6b4: e58b0020     	str	r0, [r11, #0x20]
  24e6b8: e3a00000     	mov	r0, #0
  24e6bc: e58b0024     	str	r0, [r11, #0x24]
  24e6c0: e3a00000     	mov	r0, #0
  24e6c4: ee000a10     	vmov	s0, r0
  24e6c8: eeb80ac0     	vcvt.f32.s32	s0, s0
  24e6cc: eeb72ac0     	vcvt.f64.f32	d2, s0
  24e6d0: eeb70bc2     	vcvt.f32.f64	s0, d2
  24e6d4: ed8b0a07     	vstr	s0, [r11, #28]
  24e6d8: ed9f2a00     	vldr	s4, [pc]                @ 0x24e6e0 <start+0x241c14>
  24e6dc: ea000000     	b	0x24e6e4 <start+0x241c18> @ imm = #0x0
  24e6e0: 3be56042     	bllo	0xffba67f0 <_write+0xffffffffffba67f0> @ imm = #-0x6a7ef8
  24e6e4: eeb72ac2     	vcvt.f64.f32	d2, s4
  24e6e8: e3e00000     	mvn	r0, #0
  24e6ec: ee000a10     	vmov	s0, r0
  24e6f0: eeb80ac0     	vcvt.f32.s32	s0, s0
  24e6f4: eeb73ac0     	vcvt.f64.f32	d3, s0
  24e6f8: ee222b03     	vmul.f64	d2, d2, d3
  24e6fc: eeb70bc2     	vcvt.f32.f64	s0, d2
  24e700: ed8b0a08     	vstr	s0, [r11, #32]
  24e704: ed9f2a00     	vldr	s4, [pc]                @ 0x24e70c <start+0x241c40>
  24e708: ea000000     	b	0x24e710 <start+0x241c44> @ imm = #0x0
  24e70c: 3d4ccccd     	stcllo	p12, c12, [r12, #-820]
  24e710: eeb72ac2     	vcvt.f64.f32	d2, s4
  24e714: e3e00000     	mvn	r0, #0
  24e718: ee000a10     	vmov	s0, r0
  24e71c: eeb80ac0     	vcvt.f32.s32	s0, s0
  24e720: eeb73ac0     	vcvt.f64.f32	d3, s0
  24e724: ee222b03     	vmul.f64	d2, d2, d3
  24e728: eeb70bc2     	vcvt.f32.f64	s0, d2
  24e72c: ed8b0a09     	vstr	s0, [r11, #36]
  24e730: e3a00000     	mov	r0, #0
  24e734: e58b0028     	str	r0, [r11, #0x28]
  24e738: e3a00000     	mov	r0, #0
  24e73c: e58b002c     	str	r0, [r11, #0x2c]
  24e740: e3a00000     	mov	r0, #0
  24e744: e58b0030     	str	r0, [r11, #0x30]
  24e748: e3a00000     	mov	r0, #0
  24e74c: ee000a10     	vmov	s0, r0
  24e750: eeb80ac0     	vcvt.f32.s32	s0, s0
  24e754: eeb72ac0     	vcvt.f64.f32	d2, s0
  24e758: eeb70bc2     	vcvt.f32.f64	s0, d2
  24e75c: ed8b0a0a     	vstr	s0, [r11, #40]
  24e760: ed9f2a00     	vldr	s4, [pc]                @ 0x24e768 <start+0x241c9c>
  24e764: ea000000     	b	0x24e76c <start+0x241ca0> @ imm = #0x0
  24e768: 3be56042     	bllo	0xffba6878 <_write+0xffffffffffba6878> @ imm = #-0x6a7ef8
  24e76c: eeb72ac2     	vcvt.f64.f32	d2, s4
  24e770: eeb70bc2     	vcvt.f32.f64	s0, d2
  24e774: ed8b0a0b     	vstr	s0, [r11, #44]
  24e778: ed9f2a00     	vldr	s4, [pc]                @ 0x24e780 <start+0x241cb4>
  24e77c: ea000000     	b	0x24e784 <start+0x241cb8> @ imm = #0x0
  24e780: 3d4ccccd     	stcllo	p12, c12, [r12, #-820]
  24e784: eeb72ac2     	vcvt.f64.f32	d2, s4
  24e788: eeb70bc2     	vcvt.f32.f64	s0, d2
  24e78c: ed8b0a0c     	vstr	s0, [r11, #48]
  24e790: ed9a0a0b     	vldr	s0, [r10, #44]
  24e794: eeb72ac0     	vcvt.f64.f32	d2, s0
  24e798: eeb70bc2     	vcvt.f32.f64	s0, d2
  24e79c: ed8b0a0d     	vstr	s0, [r11, #52]
  24e7a0: e28a0020     	add	r0, r10, #32
  24e7a4: ed9b0a0d     	vldr	s0, [r11, #52]
  24e7a8: eeb72ac0     	vcvt.f64.f32	d2, s0
  24e7ac: ed9b0a0a     	vldr	s0, [r11, #40]
  24e7b0: eeb73ac0     	vcvt.f64.f32	d3, s0
  24e7b4: ee222b03     	vmul.f64	d2, d2, d3
  24e7b8: ed9f3a00     	vldr	s6, [pc]                @ 0x24e7c0 <start+0x241cf4>
  24e7bc: ea000000     	b	0x24e7c4 <start+0x241cf8> @ imm = #0x0
  24e7c0: 3f800000     	svclo	#0x800000
  24e7c4: eeb73ac3     	vcvt.f64.f32	d3, s6
  24e7c8: ed9b0a0d     	vldr	s0, [r11, #52]
  24e7cc: eeb74ac0     	vcvt.f64.f32	d4, s0
  24e7d0: ee333b44     	vsub.f64	d3, d3, d4
  24e7d4: ed9b0a07     	vldr	s0, [r11, #28]
  24e7d8: eeb74ac0     	vcvt.f64.f32	d4, s0
  24e7dc: ee233b04     	vmul.f64	d3, d3, d4
  24e7e0: ee322b03     	vadd.f64	d2, d2, d3
  24e7e4: eeb70bc2     	vcvt.f32.f64	s0, d2
  24e7e8: ed800a00     	vstr	s0, [r0]
  24e7ec: e28a0020     	add	r0, r10, #32
  24e7f0: ed9b0a0d     	vldr	s0, [r11, #52]
  24e7f4: eeb72ac0     	vcvt.f64.f32	d2, s0
  24e7f8: ed9b0a0b     	vldr	s0, [r11, #44]
  24e7fc: eeb73ac0     	vcvt.f64.f32	d3, s0
  24e800: ee222b03     	vmul.f64	d2, d2, d3
  24e804: ed9f3a00     	vldr	s6, [pc]                @ 0x24e80c <start+0x241d40>
  24e808: ea000000     	b	0x24e810 <start+0x241d44> @ imm = #0x0
  24e80c: 3f800000     	svclo	#0x800000
  24e810: eeb73ac3     	vcvt.f64.f32	d3, s6
  24e814: ed9b0a0d     	vldr	s0, [r11, #52]
  24e818: eeb74ac0     	vcvt.f64.f32	d4, s0
  24e81c: ee333b44     	vsub.f64	d3, d3, d4
  24e820: ed9b0a08     	vldr	s0, [r11, #32]
  24e824: eeb74ac0     	vcvt.f64.f32	d4, s0
  24e828: ee233b04     	vmul.f64	d3, d3, d4
  24e82c: ee322b03     	vadd.f64	d2, d2, d3
  24e830: eeb70bc2     	vcvt.f32.f64	s0, d2
  24e834: ed800a01     	vstr	s0, [r0, #4]
  24e838: e28a0020     	add	r0, r10, #32
  24e83c: ed9b0a0d     	vldr	s0, [r11, #52]
  24e840: eeb72ac0     	vcvt.f64.f32	d2, s0
  24e844: ed9b0a0c     	vldr	s0, [r11, #48]
  24e848: eeb73ac0     	vcvt.f64.f32	d3, s0
  24e84c: ee222b03     	vmul.f64	d2, d2, d3
  24e850: ed9f3a00     	vldr	s6, [pc]                @ 0x24e858 <start+0x241d8c>
  24e854: ea000000     	b	0x24e85c <start+0x241d90> @ imm = #0x0
  24e858: 3f800000     	svclo	#0x800000
  24e85c: eeb73ac3     	vcvt.f64.f32	d3, s6
  24e860: ed9b0a0d     	vldr	s0, [r11, #52]
  24e864: eeb74ac0     	vcvt.f64.f32	d4, s0
  24e868: ee333b44     	vsub.f64	d3, d3, d4
  24e86c: ed9b0a09     	vldr	s0, [r11, #36]
  24e870: eeb74ac0     	vcvt.f64.f32	d4, s0
  24e874: ee233b04     	vmul.f64	d3, d3, d4
  24e878: ee322b03     	vadd.f64	d2, d2, d3
  24e87c: eeb70bc2     	vcvt.f32.f64	s0, d2
  24e880: ed800a02     	vstr	s0, [r0, #8]
  24e884: e28a0030     	add	r0, r10, #48
  24e888: ed900a00     	vldr	s0, [r0]
  24e88c: eeb72ac0     	vcvt.f64.f32	d2, s0
  24e890: e28a0020     	add	r0, r10, #32
  24e894: ed900a00     	vldr	s0, [r0]
  24e898: eeb73ac0     	vcvt.f64.f32	d3, s0
  24e89c: ee322b03     	vadd.f64	d2, d2, d3
  24e8a0: eeb02b42     	vmov.f64	d2, d2
  24e8a4: eeb02b42     	vmov.f64	d2, d2
  24e8a8: eeb70bc2     	vcvt.f32.f64	s0, d2
  24e8ac: ed8b0a16     	vstr	s0, [r11, #88]
  24e8b0: e1a0000a     	mov	r0, r10
  24e8b4: e59ae000     	ldr	lr, [r10]
  24e8b8: eb010b94     	bl	0x291710 <start+0x284c44> @ imm = #0x42e50 // UnityEngine.Transform UnityEngine.Component::get_transform()
  24e8bc: e1a02000     	mov	r2, r0
  24e8c0: e28b00dc     	add	r0, r11, #220
  24e8c4: e1a01002     	mov	r1, r2
  24e8c8: e592e000     	ldr	lr, [r2]
  24e8cc: eb010b83     	bl	0x2916e0 <start+0x284c14> @ imm = #0x42e0c // UnityEngine.Vector3 UnityEngine.Transform::get_position()
  24e8d0: e59b00dc     	ldr	r0, [r11, #0xdc]
  24e8d4: e58b005c     	str	r0, [r11, #0x5c]
  24e8d8: e59b00e0     	ldr	r0, [r11, #0xe0]
  24e8dc: e58b0060     	str	r0, [r11, #0x60]
  24e8e0: e59b00e4     	ldr	r0, [r11, #0xe4]
  24e8e4: e58b0064     	str	r0, [r11, #0x64]
  24e8e8: ed9b0a16     	vldr	s0, [r11, #88]
  24e8ec: eeb72ac0     	vcvt.f64.f32	d2, s0
  24e8f0: eeb03b42     	vmov.f64	d3, d2
  24e8f4: eeb03b43     	vmov.f64	d3, d3
  24e8f8: eeb02b43     	vmov.f64	d2, d3
  24e8fc: eeb02b42     	vmov.f64	d2, d2
  24e900: eeb03b43     	vmov.f64	d3, d3
  24e904: eeb70bc3     	vcvt.f32.f64	s0, d3
  24e908: ed8b0a22     	vstr	s0, [r11, #136]
  24e90c: eeb70bc2     	vcvt.f32.f64	s0, d2
  24e910: ed8b0a17     	vstr	s0, [r11, #92]
  24e914: e1a0000a     	mov	r0, r10
  24e918: e59ae000     	ldr	lr, [r10]
  24e91c: eb010b7b     	bl	0x291710 <start+0x284c44> @ imm = #0x42dec // UnityEngine.Transform UnityEngine.Component::get_transform()
  24e920: e1a0c000     	mov	r12, r0
  24e924: e59b005c     	ldr	r0, [r11, #0x5c]
  24e928: e58b00e8     	str	r0, [r11, #0xe8]
  24e92c: e59b0060     	ldr	r0, [r11, #0x60]
  24e930: e58b00ec     	str	r0, [r11, #0xec]
  24e934: e59b0064     	ldr	r0, [r11, #0x64]
  24e938: e58b00f0     	str	r0, [r11, #0xf0]
  24e93c: e59b00e8     	ldr	r0, [r11, #0xe8]
  24e940: e58b00f4     	str	r0, [r11, #0xf4]
  24e944: e59b00ec     	ldr	r0, [r11, #0xec]
  24e948: e58b00f8     	str	r0, [r11, #0xf8]
  24e94c: e59b00f0     	ldr	r0, [r11, #0xf0]
  24e950: e58b00fc     	str	r0, [r11, #0xfc]
  24e954: e59b00e8     	ldr	r0, [r11, #0xe8]
  24e958: e58b008c     	str	r0, [r11, #0x8c]
  24e95c: e59b00ec     	ldr	r0, [r11, #0xec]
  24e960: e58b0090     	str	r0, [r11, #0x90]
  24e964: e59b00f0     	ldr	r0, [r11, #0xf0]
  24e968: e58b0094     	str	r0, [r11, #0x94]
  24e96c: e1a0000c     	mov	r0, r12
  24e970: e59b10f4     	ldr	r1, [r11, #0xf4]
  24e974: e59b20f8     	ldr	r2, [r11, #0xf8]
  24e978: e59b30fc     	ldr	r3, [r11, #0xfc]
  24e97c: e59ce000     	ldr	lr, [r12]
  24e980: eb010b66     	bl	0x291720 <start+0x284c54> @ imm = #0x42d98 // System.Void UnityEngine.Transform::set_position(UnityEngine.Vector3)
  24e984: e28a0030     	add	r0, r10, #48
  24e988: ed900a01     	vldr	s0, [r0, #4]
  24e98c: eeb72ac0     	vcvt.f64.f32	d2, s0
  24e990: e28a0020     	add	r0, r10, #32
  24e994: ed900a01     	vldr	s0, [r0, #4]
  24e998: eeb73ac0     	vcvt.f64.f32	d3, s0
  24e99c: ee322b03     	vadd.f64	d2, d2, d3
  24e9a0: eeb02b42     	vmov.f64	d2, d2
  24e9a4: eeb02b42     	vmov.f64	d2, d2
  24e9a8: eeb70bc2     	vcvt.f32.f64	s0, d2
  24e9ac: ed8b0a1a     	vstr	s0, [r11, #104]
  24e9b0: e1a0000a     	mov	r0, r10
  24e9b4: e59ae000     	ldr	lr, [r10]
  24e9b8: eb010b54     	bl	0x291710 <start+0x284c44> @ imm = #0x42d50 // UnityEngine.Transform UnityEngine.Component::get_transform()
  24e9bc: e1a02000     	mov	r2, r0
  24e9c0: e28b0f40     	add	r0, r11, #64, #30
  24e9c4: e1a01002     	mov	r1, r2
  24e9c8: e592e000     	ldr	lr, [r2]
  24e9cc: eb010b43     	bl	0x2916e0 <start+0x284c14> @ imm = #0x42d0c // UnityEngine.Vector3 UnityEngine.Transform::get_position()
  24e9d0: e59b0100     	ldr	r0, [r11, #0x100]
  24e9d4: e58b006c     	str	r0, [r11, #0x6c]
  24e9d8: e59b0104     	ldr	r0, [r11, #0x104]
  24e9dc: e58b0070     	str	r0, [r11, #0x70]
  24e9e0: e59b0108     	ldr	r0, [r11, #0x108]
  24e9e4: e58b0074     	str	r0, [r11, #0x74]
  24e9e8: ed9b0a1a     	vldr	s0, [r11, #104]
  24e9ec: eeb72ac0     	vcvt.f64.f32	d2, s0
  24e9f0: eeb03b42     	vmov.f64	d3, d2
  24e9f4: eeb03b43     	vmov.f64	d3, d3
  24e9f8: eeb02b43     	vmov.f64	d2, d3
  24e9fc: eeb02b42     	vmov.f64	d2, d2
  24ea00: eeb03b43     	vmov.f64	d3, d3
  24ea04: eeb70bc3     	vcvt.f32.f64	s0, d3
  24ea08: ed8b0a26     	vstr	s0, [r11, #152]
  24ea0c: eeb70bc2     	vcvt.f32.f64	s0, d2
  24ea10: ed8b0a1c     	vstr	s0, [r11, #112]
  24ea14: e1a0000a     	mov	r0, r10
  24ea18: e59ae000     	ldr	lr, [r10]
  24ea1c: eb010b3b     	bl	0x291710 <start+0x284c44> @ imm = #0x42cec // UnityEngine.Transform UnityEngine.Component::get_transform()
  24ea20: e1a0c000     	mov	r12, r0
  24ea24: e59b006c     	ldr	r0, [r11, #0x6c]
  24ea28: e58b010c     	str	r0, [r11, #0x10c]
  24ea2c: e59b0070     	ldr	r0, [r11, #0x70]
  24ea30: e58b0110     	str	r0, [r11, #0x110]
  24ea34: e59b0074     	ldr	r0, [r11, #0x74]
  24ea38: e58b0114     	str	r0, [r11, #0x114]
  24ea3c: e59b010c     	ldr	r0, [r11, #0x10c]
  24ea40: e58b0118     	str	r0, [r11, #0x118]
  24ea44: e59b0110     	ldr	r0, [r11, #0x110]
  24ea48: e58b011c     	str	r0, [r11, #0x11c]
  24ea4c: e59b0114     	ldr	r0, [r11, #0x114]
  24ea50: e58b0120     	str	r0, [r11, #0x120]
  24ea54: e59b010c     	ldr	r0, [r11, #0x10c]
  24ea58: e58b009c     	str	r0, [r11, #0x9c]
  24ea5c: e59b0110     	ldr	r0, [r11, #0x110]
  24ea60: e58b00a0     	str	r0, [r11, #0xa0]
  24ea64: e59b0114     	ldr	r0, [r11, #0x114]
  24ea68: e58b00a4     	str	r0, [r11, #0xa4]
  24ea6c: e1a0000c     	mov	r0, r12
  24ea70: e59b1118     	ldr	r1, [r11, #0x118]
  24ea74: e59b211c     	ldr	r2, [r11, #0x11c]
  24ea78: e59b3120     	ldr	r3, [r11, #0x120]
  24ea7c: e59ce000     	ldr	lr, [r12]
  24ea80: eb010b26     	bl	0x291720 <start+0x284c54> @ imm = #0x42c98 // System.Void UnityEngine.Transform::set_position(UnityEngine.Vector3)
  24ea84: e28a0030     	add	r0, r10, #48
  24ea88: ed900a02     	vldr	s0, [r0, #8]
  24ea8c: eeb72ac0     	vcvt.f64.f32	d2, s0
  24ea90: e28a0020     	add	r0, r10, #32
  24ea94: ed900a02     	vldr	s0, [r0, #8]
  24ea98: eeb73ac0     	vcvt.f64.f32	d3, s0
  24ea9c: ee322b03     	vadd.f64	d2, d2, d3
  24eaa0: eeb02b42     	vmov.f64	d2, d2
  24eaa4: eeb02b42     	vmov.f64	d2, d2
  24eaa8: eeb70bc2     	vcvt.f32.f64	s0, d2
  24eaac: ed8b0a1e     	vstr	s0, [r11, #120]
  24eab0: e1a0000a     	mov	r0, r10
  24eab4: e59ae000     	ldr	lr, [r10]
  24eab8: eb010b14     	bl	0x291710 <start+0x284c44> @ imm = #0x42c50 // UnityEngine.Transform UnityEngine.Component::get_transform()
  24eabc: e1a02000     	mov	r2, r0
  24eac0: e28b0f49     	add	r0, r11, #292
  24eac4: e1a01002     	mov	r1, r2
  24eac8: e592e000     	ldr	lr, [r2]
  24eacc: eb010b03     	bl	0x2916e0 <start+0x284c14> @ imm = #0x42c0c // UnityEngine.Vector3 UnityEngine.Transform::get_position()
  24ead0: e59b0124     	ldr	r0, [r11, #0x124]
  24ead4: e58b007c     	str	r0, [r11, #0x7c]
  24ead8: e59b0128     	ldr	r0, [r11, #0x128]
  24eadc: e58b0080     	str	r0, [r11, #0x80]
  24eae0: e59b012c     	ldr	r0, [r11, #0x12c]
  24eae4: e58b0084     	str	r0, [r11, #0x84]
  24eae8: ed9b0a1e     	vldr	s0, [r11, #120]
  24eaec: eeb72ac0     	vcvt.f64.f32	d2, s0
  24eaf0: eeb03b42     	vmov.f64	d3, d2
  24eaf4: eeb03b43     	vmov.f64	d3, d3
  24eaf8: eeb02b43     	vmov.f64	d2, d3
  24eafc: eeb02b42     	vmov.f64	d2, d2
  24eb00: eeb03b43     	vmov.f64	d3, d3
  24eb04: eeb70bc3     	vcvt.f32.f64	s0, d3
  24eb08: ed8b0a2a     	vstr	s0, [r11, #168]
  24eb0c: eeb70bc2     	vcvt.f32.f64	s0, d2
  24eb10: ed8b0a21     	vstr	s0, [r11, #132]
  24eb14: e1a0000a     	mov	r0, r10
  24eb18: e59ae000     	ldr	lr, [r10]
  24eb1c: eb010afb     	bl	0x291710 <start+0x284c44> @ imm = #0x42bec // UnityEngine.Transform UnityEngine.Component::get_transform()
  24eb20: e1a0c000     	mov	r12, r0
  24eb24: e59b007c     	ldr	r0, [r11, #0x7c]
  24eb28: e58b0130     	str	r0, [r11, #0x130]
  24eb2c: e59b0080     	ldr	r0, [r11, #0x80]
  24eb30: e58b0134     	str	r0, [r11, #0x134]
  24eb34: e59b0084     	ldr	r0, [r11, #0x84]
  24eb38: e58b0138     	str	r0, [r11, #0x138]
  24eb3c: e59b0130     	ldr	r0, [r11, #0x130]
  24eb40: e58b013c     	str	r0, [r11, #0x13c]
  24eb44: e59b0134     	ldr	r0, [r11, #0x134]
  24eb48: e58b0140     	str	r0, [r11, #0x140]
  24eb4c: e59b0138     	ldr	r0, [r11, #0x138]
  24eb50: e58b0144     	str	r0, [r11, #0x144]
  24eb54: e59b0130     	ldr	r0, [r11, #0x130]
  24eb58: e58b00ac     	str	r0, [r11, #0xac]
  24eb5c: e59b0134     	ldr	r0, [r11, #0x134]
  24eb60: e58b00b0     	str	r0, [r11, #0xb0]
  24eb64: e59b0138     	ldr	r0, [r11, #0x138]
  24eb68: e58b00b4     	str	r0, [r11, #0xb4]
  24eb6c: e1a0000c     	mov	r0, r12
  24eb70: e59b113c     	ldr	r1, [r11, #0x13c]
  24eb74: e59b2140     	ldr	r2, [r11, #0x140]
  24eb78: e59b3144     	ldr	r3, [r11, #0x144]
  24eb7c: e59ce000     	ldr	lr, [r12]
  24eb80: eb010ae6     	bl	0x291720 <start+0x284c54> @ imm = #0x42b98 // System.Void UnityEngine.Transform::set_position(UnityEngine.Vector3)
  24eb84: e5da0018     	ldrb	r0, [r10, #0x18]
  24eb88: e3500000     	cmp	r0, #0
  24eb8c: 0a000071     	beq	0x24ed58 <start+0x24228c> @ imm = #0x1c4
  24eb90: e59a2010     	ldr	r2, [r10, #0x10]
  24eb94: e28b0f52     	add	r0, r11, #328
  24eb98: e1a01002     	mov	r1, r2
  24eb9c: e592e000     	ldr	lr, [r2]
  24eba0: eb010ace     	bl	0x2916e0 <start+0x284c14> @ imm = #0x42b38 // UnityEngine.Vector3 UnityEngine.Transform::get_position()
  24eba4: e1a0000a     	mov	r0, r10
  24eba8: e59ae000     	ldr	lr, [r10]
  24ebac: eb010ad7     	bl	0x291710 <start+0x284c44> @ imm = #0x42b5c // UnityEngine.Transform UnityEngine.Component::get_transform()
  24ebb0: e1a02000     	mov	r2, r0
  24ebb4: e28b0f55     	add	r0, r11, #340
  24ebb8: e1a01002     	mov	r1, r2
  24ebbc: e592e000     	ldr	lr, [r2]
  24ebc0: eb010ac6     	bl	0x2916e0 <start+0x284c14> @ imm = #0x42b18 // UnityEngine.Vector3 UnityEngine.Transform::get_position()
  24ebc4: e28b0038     	add	r0, r11, #56
  24ebc8: e59b1148     	ldr	r1, [r11, #0x148]
  24ebcc: e59b214c     	ldr	r2, [r11, #0x14c]
  24ebd0: e59b3150     	ldr	r3, [r11, #0x150]
  24ebd4: e59bc154     	ldr	r12, [r11, #0x154]
  24ebd8: e58dc000     	str	r12, [sp]
  24ebdc: e59bc158     	ldr	r12, [r11, #0x158]
  24ebe0: e58dc004     	str	r12, [sp, #0x4]
  24ebe4: e59bc15c     	ldr	r12, [r11, #0x15c]
  24ebe8: e58dc008     	str	r12, [sp, #0x8]
  24ebec: eb010d1f     	bl	0x292070 <start+0x2855a4> @ imm = #0x4347c // UnityEngine.Vector3 UnityEngine.Vector3::op_Subtraction(UnityEngine.Vector3,UnityEngine.Vector3)
  24ebf0: ed9b0a0f     	vldr	s0, [r11, #60]
  24ebf4: eeb72ac0     	vcvt.f64.f32	d2, s0
  24ebf8: ed9a0a07     	vldr	s0, [r10, #28]
  24ebfc: eeb73ac0     	vcvt.f64.f32	d3, s0
  24ec00: ee322b03     	vadd.f64	d2, d2, d3
  24ec04: eeb70bc2     	vcvt.f32.f64	s0, d2
  24ec08: ed8b0a0f     	vstr	s0, [r11, #60]
  24ec0c: ed9f2a00     	vldr	s4, [pc]                @ 0x24ec14 <start+0x242148>
  24ec10: ea000000     	b	0x24ec18 <start+0x24214c> @ imm = #0x0
  24ec14: 40a00000     	adcmi	r0, r0, r0
  24ec18: eeb72ac2     	vcvt.f64.f32	d2, s4
  24ec1c: e3e00000     	mvn	r0, #0
  24ec20: ee000a10     	vmov	s0, r0
  24ec24: eeb80ac0     	vcvt.f32.s32	s0, s0
  24ec28: eeb73ac0     	vcvt.f64.f32	d3, s0
  24ec2c: ee222b03     	vmul.f64	d2, d2, d3
  24ec30: eeb70bc2     	vcvt.f32.f64	s0, d2
  24ec34: ed8b0a11     	vstr	s0, [r11, #68]
  24ec38: ed9b0a0f     	vldr	s0, [r11, #60]
  24ec3c: eeb72ac0     	vcvt.f64.f32	d2, s0
  24ec40: ed9b0a11     	vldr	s0, [r11, #68]
  24ec44: eeb73ac0     	vcvt.f64.f32	d3, s0
  24ec48: eeb42b43     	vcmp.f64	d2, d3
  24ec4c: eef1fa10     	vmrs	APSR_nzcv, fpscr
  24ec50: e3a00000     	mov	r0, #0
  24ec54: 43a00001     	movmi	r0, #1
  24ec58: e3500000     	cmp	r0, #0
  24ec5c: 0a000003     	beq	0x24ec70 <start+0x2421a4> @ imm = #0xc
  24ec60: ed9b0a11     	vldr	s0, [r11, #68]
  24ec64: eeb72ac0     	vcvt.f64.f32	d2, s0
  24ec68: eeb70bc2     	vcvt.f32.f64	s0, d2
  24ec6c: ed8b0a0f     	vstr	s0, [r11, #60]
  24ec70: e59b0038     	ldr	r0, [r11, #0x38]
  24ec74: e58b0160     	str	r0, [r11, #0x160]
  24ec78: e59b003c     	ldr	r0, [r11, #0x3c]
  24ec7c: e58b0164     	str	r0, [r11, #0x164]
  24ec80: e59b0040     	ldr	r0, [r11, #0x40]
  24ec84: e58b0168     	str	r0, [r11, #0x168]
  24ec88: e28b0048     	add	r0, r11, #72
  24ec8c: e59b1160     	ldr	r1, [r11, #0x160]
  24ec90: e59b2164     	ldr	r2, [r11, #0x164]
  24ec94: e59b3168     	ldr	r3, [r11, #0x168]
  24ec98: eb010d10     	bl	0x2920e0 <start+0x285614> @ imm = #0x43440 // UnityEngine.Quaternion UnityEngine.Quaternion::LookRotation(UnityEngine.Vector3)
  24ec9c: e1a0000a     	mov	r0, r10
  24eca0: e59ae000     	ldr	lr, [r10]
  24eca4: eb010a99     	bl	0x291710 <start+0x284c44> @ imm = #0x42a64 // UnityEngine.Transform UnityEngine.Component::get_transform()
  24eca8: e58b0194     	str	r0, [r11, #0x194]
  24ecac: e1a0000a     	mov	r0, r10
  24ecb0: e59ae000     	ldr	lr, [r10]
  24ecb4: eb010a95     	bl	0x291710 <start+0x284c44> @ imm = #0x42a54 // UnityEngine.Transform UnityEngine.Component::get_transform()
  24ecb8: e1a02000     	mov	r2, r0
  24ecbc: e28b0f5b     	add	r0, r11, #364
  24ecc0: e1a01002     	mov	r1, r2
  24ecc4: e592e000     	ldr	lr, [r2]
  24ecc8: eb010d08     	bl	0x2920f0 <start+0x285624> @ imm = #0x43420 // UnityEngine.Quaternion UnityEngine.Transform::get_rotation()
  24eccc: eb010ccf     	bl	0x292010 <start+0x285544> @ imm = #0x4333c // System.Single UnityEngine.Time::get_deltaTime()
  24ecd0: ee020a10     	vmov	s4, r0
  24ecd4: eeb72ac2     	vcvt.f64.f32	d2, s4
  24ecd8: ed9a0a05     	vldr	s0, [r10, #20]
  24ecdc: eeb73ac0     	vcvt.f64.f32	d3, s0
  24ece0: ee222b03     	vmul.f64	d2, d2, d3
  24ece4: e28b0f5f     	add	r0, r11, #380
  24ece8: e59b116c     	ldr	r1, [r11, #0x16c]
  24ecec: e59b2170     	ldr	r2, [r11, #0x170]
  24ecf0: e59b3174     	ldr	r3, [r11, #0x174]
  24ecf4: e59bc178     	ldr	r12, [r11, #0x178]
  24ecf8: e58dc000     	str	r12, [sp]
  24ecfc: e59bc048     	ldr	r12, [r11, #0x48]
  24ed00: e58dc004     	str	r12, [sp, #0x4]
  24ed04: e59bc04c     	ldr	r12, [r11, #0x4c]
  24ed08: e58dc008     	str	r12, [sp, #0x8]
  24ed0c: e59bc050     	ldr	r12, [r11, #0x50]
  24ed10: e58dc00c     	str	r12, [sp, #0xc]
  24ed14: e59bc054     	ldr	r12, [r11, #0x54]
  24ed18: e58dc010     	str	r12, [sp, #0x10]
  24ed1c: eeb70bc2     	vcvt.f32.f64	s0, d2
  24ed20: ed8d0a05     	vstr	s0, [sp, #20]
  24ed24: eb010cf5     	bl	0x292100 <start+0x285634> @ imm = #0x433d4 // UnityEngine.Quaternion UnityEngine.Quaternion::Slerp(UnityEngine.Quaternion,UnityEngine.Quaternion,System.Single)
  24ed28: e59bc194     	ldr	r12, [r11, #0x194]
  24ed2c: e1a0000c     	mov	r0, r12
  24ed30: e58b0190     	str	r0, [r11, #0x190]
  24ed34: e59b117c     	ldr	r1, [r11, #0x17c]
  24ed38: e59b2180     	ldr	r2, [r11, #0x180]
  24ed3c: e59b3184     	ldr	r3, [r11, #0x184]
  24ed40: e59b0188     	ldr	r0, [r11, #0x188]
  24ed44: e58d0000     	str	r0, [sp]
  24ed48: e59b0190     	ldr	r0, [r11, #0x190]
  24ed4c: e59ce000     	ldr	lr, [r12]
  24ed50: eb010cee     	bl	0x292110 <start+0x285644> @ imm = #0x433b8 // System.Void UnityEngine.Transform::set_rotation(UnityEngine.Quaternion)
  24ed54: ea000007     	b	0x24ed78 <start+0x2422ac> @ imm = #0x1c
  24ed58: e1a0000a     	mov	r0, r10
  24ed5c: e59ae000     	ldr	lr, [r10]
  24ed60: eb010a6a     	bl	0x291710 <start+0x284c44> @ imm = #0x429a8 // UnityEngine.Transform UnityEngine.Component::get_transform()
  24ed64: e1a02000     	mov	r2, r0
  24ed68: e59a1010     	ldr	r1, [r10, #0x10]
  24ed6c: e1a00002     	mov	r0, r2
  24ed70: e592e000     	ldr	lr, [r2]
  24ed74: eb010cc1     	bl	0x292080 <start+0x2855b4> @ imm = #0x43304 // System.Void UnityEngine.Transform::LookAt(UnityEngine.Transform)
  24ed78: e28bdf67     	add	sp, r11, #412
  24ed7c: e8bd0d00     	pop	{r8, r10, r11}
  24ed80: e59d7008     	ldr	r7, [sp, #0x8]
  24ed84: e89da000     	ldm	sp, {sp, pc}
