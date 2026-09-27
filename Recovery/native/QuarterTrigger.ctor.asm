
/Users/tomato/Documents/Codex/iQuarters/Recovery/native/iquarters-armv7:	file format mach-o arm

Disassembly of section __TEXT,__text:

0000cacc <start>:
  24f8f8: e1a0c00d     	mov	r12, sp
  24f8fc: e92d4080     	push	{r7, lr}
  24f900: e1a0700d     	mov	r7, sp
  24f904: e92d5d00     	push	{r8, r10, r11, r12, lr}
  24f908: e24dd014     	sub	sp, sp, #20
  24f90c: e1a0b00d     	mov	r11, sp
  24f910: e1a0a000     	mov	r10, r0
  24f914: e1a0000a     	mov	r0, r10
  24f918: eb0106f0     	bl	0x2914e0 <start+0x284a14> @ imm = #0x41bc0 // System.Void UnityEngine.MonoBehaviour::.ctor()
  24f91c: e3a00000     	mov	r0, #0
  24f920: e58a0294     	str	r0, [r10, #0x294]
  24f924: e3a00000     	mov	r0, #0
  24f928: e58a0298     	str	r0, [r10, #0x298]
  24f92c: e3a0000a     	mov	r0, #10
  24f930: e58a029c     	str	r0, [r10, #0x29c]
  24f934: e3a00000     	mov	r0, #0
  24f938: e58a02a0     	str	r0, [r10, #0x2a0]
  24f93c: e3a00000     	mov	r0, #0
  24f940: e58a02a4     	str	r0, [r10, #0x2a4]
  24f944: e3a000c8     	mov	r0, #200
  24f948: e58a02a8     	str	r0, [r10, #0x2a8]
  24f94c: ed9f2a00     	vldr	s4, [pc]                @ 0x24f954 <start+0x242e88>
  24f950: ea000000     	b	0x24f958 <start+0x242e8c> @ imm = #0x0
  24f954: 3f800000     	svclo	#0x800000
  24f958: eeb72ac2     	vcvt.f64.f32	d2, s4
  24f95c: eeb70bc2     	vcvt.f32.f64	s0, d2
  24f960: ed8a0aab     	vstr	s0, [r10, #684]
  24f964: e3a00014     	mov	r0, #20
  24f968: e58a02b0     	str	r0, [r10, #0x2b0]
  24f96c: e3a00000     	mov	r0, #0
  24f970: e58a02b4     	str	r0, [r10, #0x2b4]
  24f974: e3a0000a     	mov	r0, #10
  24f978: e58a02c8     	str	r0, [r10, #0x2c8]
  24f97c: e3a0000b     	mov	r0, #11
  24f980: e58a02cc     	str	r0, [r10, #0x2cc]
  24f984: e59a02c8     	ldr	r0, [r10, #0x2c8]
  24f988: e58a02d0     	str	r0, [r10, #0x2d0]
  24f98c: e3a00000     	mov	r0, #0
  24f990: e58a02d4     	str	r0, [r10, #0x2d4]
  24f994: e3a00001     	mov	r0, #1
  24f998: e5ca02d8     	strb	r0, [r10, #0x2d8]
  24f99c: e3a00000     	mov	r0, #0
  24f9a0: ee000a10     	vmov	s0, r0
  24f9a4: eeb80ac0     	vcvt.f32.s32	s0, s0
  24f9a8: eeb72ac0     	vcvt.f64.f32	d2, s0
  24f9ac: eeb70bc2     	vcvt.f32.f64	s0, d2
  24f9b0: ed8a0ab7     	vstr	s0, [r10, #732]
  24f9b4: e3a00000     	mov	r0, #0
  24f9b8: ee000a10     	vmov	s0, r0
  24f9bc: eeb80ac0     	vcvt.f32.s32	s0, s0
  24f9c0: eeb72ac0     	vcvt.f64.f32	d2, s0
  24f9c4: eeb70bc2     	vcvt.f32.f64	s0, d2
  24f9c8: ed8a0ab8     	vstr	s0, [r10, #736]
  24f9cc: e3e00000     	mvn	r0, #0
  24f9d0: e58a02e4     	str	r0, [r10, #0x2e4]
  24f9d4: e3a00000     	mov	r0, #0
  24f9d8: e58a02e8     	str	r0, [r10, #0x2e8]
  24f9dc: e59f0000     	ldr	r0, [pc]                @ 0x24f9e4 <start+0x242f18>
  24f9e0: ea000000     	b	0x24f9e8 <start+0x242f1c> @ imm = #0x0
  24f9e4: 005013e0     	subseq	r1, r0, r0, ror #7
  24f9e8: e79f0000     	ldr	r0, [pc, r0]
  24f9ec: eb0108c3     	bl	0x291d00 <start+0x285234> @ imm = #0x4230c
  24f9f0: e58b0008     	str	r0, [r11, #0x8]
  24f9f4: eb0108c5     	bl	0x291d10 <start+0x285244> @ imm = #0x42314
  24f9f8: e59b0008     	ldr	r0, [r11, #0x8]
  24f9fc: e58a002c     	str	r0, [r10, #0x2c]
  24fa00: e3a00000     	mov	r0, #0
  24fa04: e58a02ec     	str	r0, [r10, #0x2ec]
  24fa08: e3a00000     	mov	r0, #0
  24fa0c: ee000a10     	vmov	s0, r0
  24fa10: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fa14: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fa18: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fa1c: ed8a0abc     	vstr	s0, [r10, #752]
  24fa20: e3e00000     	mvn	r0, #0
  24fa24: e58a02f4     	str	r0, [r10, #0x2f4]
  24fa28: ed9f2a00     	vldr	s4, [pc]                @ 0x24fa30 <start+0x242f64>
  24fa2c: ea000000     	b	0x24fa34 <start+0x242f68> @ imm = #0x0
  24fa30: 3c23d70a     	stclo	p7, c13, [r3], #-40
  24fa34: eeb72ac2     	vcvt.f64.f32	d2, s4
  24fa38: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fa3c: ed8a0abe     	vstr	s0, [r10, #760]
  24fa40: e3a0001e     	mov	r0, #30
  24fa44: e58a02fc     	str	r0, [r10, #0x2fc]
  24fa48: e3a00003     	mov	r0, #3
  24fa4c: e58a0300     	str	r0, [r10, #0x300]
  24fa50: e3a00000     	mov	r0, #0
  24fa54: e58a0304     	str	r0, [r10, #0x304]
  24fa58: e3a00000     	mov	r0, #0
  24fa5c: ee000a10     	vmov	s0, r0
  24fa60: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fa64: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fa68: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fa6c: ed8a0ac2     	vstr	s0, [r10, #776]
  24fa70: e3a00000     	mov	r0, #0
  24fa74: e58a030c     	str	r0, [r10, #0x30c]
  24fa78: e3a00000     	mov	r0, #0
  24fa7c: e58a0310     	str	r0, [r10, #0x310]
  24fa80: ed9f2a00     	vldr	s4, [pc]                @ 0x24fa88 <start+0x242fbc>
  24fa84: ea000000     	b	0x24fa8c <start+0x242fc0> @ imm = #0x0
  24fa88: 41a00000     	movmi	r0, r0
  24fa8c: eeb72ac2     	vcvt.f64.f32	d2, s4
  24fa90: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fa94: ed8a0ac5     	vstr	s0, [r10, #788]
  24fa98: e59f0000     	ldr	r0, [pc]                @ 0x24faa0 <start+0x242fd4>
  24fa9c: ea000000     	b	0x24faa4 <start+0x242fd8> @ imm = #0x0
  24faa0: 00501444     	subseq	r1, r0, r4, asr #8
  24faa4: e79f0000     	ldr	r0, [pc, r0]
  24faa8: e5900000     	ldr	r0, [r0]
  24faac: e58a00cc     	str	r0, [r10, #0xcc]
  24fab0: e59f0000     	ldr	r0, [pc]                @ 0x24fab8 <start+0x242fec>
  24fab4: ea000000     	b	0x24fabc <start+0x242ff0> @ imm = #0x0
  24fab8: 0050130c     	subseq	r1, r0, r12, lsl #6
  24fabc: e79f0000     	ldr	r0, [pc, r0]
  24fac0: eb01088e     	bl	0x291d00 <start+0x285234> @ imm = #0x42238
  24fac4: e58b0004     	str	r0, [r11, #0x4]
  24fac8: eb010890     	bl	0x291d10 <start+0x285244> @ imm = #0x42240
  24facc: e59b0004     	ldr	r0, [r11, #0x4]
  24fad0: e58a00d4     	str	r0, [r10, #0xd4]
  24fad4: e3a0000f     	mov	r0, #15
  24fad8: e58a0340     	str	r0, [r10, #0x340]
  24fadc: e3a00000     	mov	r0, #0
  24fae0: e58a0344     	str	r0, [r10, #0x344]
  24fae4: e59f0000     	ldr	r0, [pc]                @ 0x24faec <start+0x243020>
  24fae8: ea000000     	b	0x24faf0 <start+0x243024> @ imm = #0x0
  24faec: 005013f8     	ldrsheq	r1, [r0], #-56
  24faf0: e79f0000     	ldr	r0, [pc, r0]
  24faf4: e5900000     	ldr	r0, [r0]
  24faf8: e58a00d8     	str	r0, [r10, #0xd8]
  24fafc: e59f0000     	ldr	r0, [pc]                @ 0x24fb04 <start+0x243038>
  24fb00: ea000000     	b	0x24fb08 <start+0x24303c> @ imm = #0x0
  24fb04: 005013e0     	subseq	r1, r0, r0, ror #7
  24fb08: e79f0000     	ldr	r0, [pc, r0]
  24fb0c: e5900000     	ldr	r0, [r0]
  24fb10: e58a00dc     	str	r0, [r10, #0xdc]
  24fb14: e59f0000     	ldr	r0, [pc]                @ 0x24fb1c <start+0x243050>
  24fb18: ea000000     	b	0x24fb20 <start+0x243054> @ imm = #0x0
  24fb1c: 005013c8     	subseq	r1, r0, r8, asr #7
  24fb20: e79f0000     	ldr	r0, [pc, r0]
  24fb24: e5900000     	ldr	r0, [r0]
  24fb28: e58a00e0     	str	r0, [r10, #0xe0]
  24fb2c: e59f0000     	ldr	r0, [pc]                @ 0x24fb34 <start+0x243068>
  24fb30: ea000000     	b	0x24fb38 <start+0x24306c> @ imm = #0x0
  24fb34: 005013b0     	ldrheq	r1, [r0], #-48
  24fb38: e79f0000     	ldr	r0, [pc, r0]
  24fb3c: e5900000     	ldr	r0, [r0]
  24fb40: e58a00e4     	str	r0, [r10, #0xe4]
  24fb44: e59f0000     	ldr	r0, [pc]                @ 0x24fb4c <start+0x243080>
  24fb48: ea000000     	b	0x24fb50 <start+0x243084> @ imm = #0x0
  24fb4c: 00501398     	<unknown>
  24fb50: e79f0000     	ldr	r0, [pc, r0]
  24fb54: e5900000     	ldr	r0, [r0]
  24fb58: e58a00e8     	str	r0, [r10, #0xe8]
  24fb5c: e59f0000     	ldr	r0, [pc]                @ 0x24fb64 <start+0x243098>
  24fb60: ea000000     	b	0x24fb68 <start+0x24309c> @ imm = #0x0
  24fb64: 00501380     	subseq	r1, r0, r0, lsl #7
  24fb68: e79f0000     	ldr	r0, [pc, r0]
  24fb6c: e5900000     	ldr	r0, [r0]
  24fb70: e58a00ec     	str	r0, [r10, #0xec]
  24fb74: e59f0000     	ldr	r0, [pc]                @ 0x24fb7c <start+0x2430b0>
  24fb78: ea000000     	b	0x24fb80 <start+0x2430b4> @ imm = #0x0
  24fb7c: 00501368     	subseq	r1, r0, r8, ror #6
  24fb80: e79f0000     	ldr	r0, [pc, r0]
  24fb84: e5900000     	ldr	r0, [r0]
  24fb88: e58a00f0     	str	r0, [r10, #0xf0]
  24fb8c: e59f0000     	ldr	r0, [pc]                @ 0x24fb94 <start+0x2430c8>
  24fb90: ea000000     	b	0x24fb98 <start+0x2430cc> @ imm = #0x0
  24fb94: 00501350     	subseq	r1, r0, r0, asr r3
  24fb98: e79f0000     	ldr	r0, [pc, r0]
  24fb9c: e5900000     	ldr	r0, [r0]
  24fba0: e58a00f4     	str	r0, [r10, #0xf4]
  24fba4: e59f0000     	ldr	r0, [pc]                @ 0x24fbac <start+0x2430e0>
  24fba8: ea000000     	b	0x24fbb0 <start+0x2430e4> @ imm = #0x0
  24fbac: 00501338     	subseq	r1, r0, r8, lsr r3
  24fbb0: e79f0000     	ldr	r0, [pc, r0]
  24fbb4: e5900000     	ldr	r0, [r0]
  24fbb8: e58a00f8     	str	r0, [r10, #0xf8]
  24fbbc: e59f0000     	ldr	r0, [pc]                @ 0x24fbc4 <start+0x2430f8>
  24fbc0: ea000000     	b	0x24fbc8 <start+0x2430fc> @ imm = #0x0
  24fbc4: 00501320     	subseq	r1, r0, r0, lsr #6
  24fbc8: e79f0000     	ldr	r0, [pc, r0]
  24fbcc: e5900000     	ldr	r0, [r0]
  24fbd0: e58a00fc     	str	r0, [r10, #0xfc]
  24fbd4: e59f0000     	ldr	r0, [pc]                @ 0x24fbdc <start+0x243110>
  24fbd8: ea000000     	b	0x24fbe0 <start+0x243114> @ imm = #0x0
  24fbdc: 00501308     	subseq	r1, r0, r8, lsl #6
  24fbe0: e79f0000     	ldr	r0, [pc, r0]
  24fbe4: e5900000     	ldr	r0, [r0]
  24fbe8: e58a0100     	str	r0, [r10, #0x100]
  24fbec: e59f0000     	ldr	r0, [pc]                @ 0x24fbf4 <start+0x243128>
  24fbf0: ea000000     	b	0x24fbf8 <start+0x24312c> @ imm = #0x0
  24fbf4: 005012f0     	ldrsheq	r1, [r0], #-32
  24fbf8: e79f0000     	ldr	r0, [pc, r0]
  24fbfc: e5900000     	ldr	r0, [r0]
  24fc00: e58a0104     	str	r0, [r10, #0x104]
  24fc04: e59f0000     	ldr	r0, [pc]                @ 0x24fc0c <start+0x243140>
  24fc08: ea000000     	b	0x24fc10 <start+0x243144> @ imm = #0x0
  24fc0c: 005012d8     	ldrsbeq	r1, [r0], #-40
  24fc10: e79f0000     	ldr	r0, [pc, r0]
  24fc14: e5900000     	ldr	r0, [r0]
  24fc18: e58a0108     	str	r0, [r10, #0x108]
  24fc1c: e59f0000     	ldr	r0, [pc]                @ 0x24fc24 <start+0x243158>
  24fc20: ea000000     	b	0x24fc28 <start+0x24315c> @ imm = #0x0
  24fc24: 005012c0     	subseq	r1, r0, r0, asr #5
  24fc28: e79f0000     	ldr	r0, [pc, r0]
  24fc2c: e5900000     	ldr	r0, [r0]
  24fc30: e58a010c     	str	r0, [r10, #0x10c]
  24fc34: e59f0000     	ldr	r0, [pc]                @ 0x24fc3c <start+0x243170>
  24fc38: ea000000     	b	0x24fc40 <start+0x243174> @ imm = #0x0
  24fc3c: 005012a8     	subseq	r1, r0, r8, lsr #5
  24fc40: e79f0000     	ldr	r0, [pc, r0]
  24fc44: e5900000     	ldr	r0, [r0]
  24fc48: e58a0110     	str	r0, [r10, #0x110]
  24fc4c: e59f0000     	ldr	r0, [pc]                @ 0x24fc54 <start+0x243188>
  24fc50: ea000000     	b	0x24fc58 <start+0x24318c> @ imm = #0x0
  24fc54: 00501290     	<unknown>
  24fc58: e79f0000     	ldr	r0, [pc, r0]
  24fc5c: e5900000     	ldr	r0, [r0]
  24fc60: e58a0114     	str	r0, [r10, #0x114]
  24fc64: e59f0000     	ldr	r0, [pc]                @ 0x24fc6c <start+0x2431a0>
  24fc68: ea000000     	b	0x24fc70 <start+0x2431a4> @ imm = #0x0
  24fc6c: 00501158     	subseq	r1, r0, r8, asr r1
  24fc70: e79f0000     	ldr	r0, [pc, r0]
  24fc74: eb010821     	bl	0x291d00 <start+0x285234> @ imm = #0x42084
  24fc78: e58b0000     	str	r0, [r11]
  24fc7c: eb010823     	bl	0x291d10 <start+0x285244> @ imm = #0x4208c
  24fc80: e59b0000     	ldr	r0, [r11]
  24fc84: e58a0118     	str	r0, [r10, #0x118]
  24fc88: e3a00000     	mov	r0, #0
  24fc8c: e58a0348     	str	r0, [r10, #0x348]
  24fc90: e3a0000a     	mov	r0, #10
  24fc94: e58a034c     	str	r0, [r10, #0x34c]
  24fc98: e3a00000     	mov	r0, #0
  24fc9c: e58a011c     	str	r0, [r10, #0x11c]
  24fca0: e3a00000     	mov	r0, #0
  24fca4: e58a0120     	str	r0, [r10, #0x120]
  24fca8: e3a00000     	mov	r0, #0
  24fcac: e58a0124     	str	r0, [r10, #0x124]
  24fcb0: e3a00000     	mov	r0, #0
  24fcb4: e58a0128     	str	r0, [r10, #0x128]
  24fcb8: e3a00000     	mov	r0, #0
  24fcbc: e58a012c     	str	r0, [r10, #0x12c]
  24fcc0: e3a00000     	mov	r0, #0
  24fcc4: e58a0130     	str	r0, [r10, #0x130]
  24fcc8: e3a00000     	mov	r0, #0
  24fccc: e58a0134     	str	r0, [r10, #0x134]
  24fcd0: e3a00000     	mov	r0, #0
  24fcd4: e58a0138     	str	r0, [r10, #0x138]
  24fcd8: e3a00000     	mov	r0, #0
  24fcdc: e58a013c     	str	r0, [r10, #0x13c]
  24fce0: e3a00000     	mov	r0, #0
  24fce4: e58a0140     	str	r0, [r10, #0x140]
  24fce8: e3a00000     	mov	r0, #0
  24fcec: e58a0144     	str	r0, [r10, #0x144]
  24fcf0: e3a00000     	mov	r0, #0
  24fcf4: e58a0148     	str	r0, [r10, #0x148]
  24fcf8: e3a00000     	mov	r0, #0
  24fcfc: e58a014c     	str	r0, [r10, #0x14c]
  24fd00: e3a00000     	mov	r0, #0
  24fd04: e58a0150     	str	r0, [r10, #0x150]
  24fd08: e3a00000     	mov	r0, #0
  24fd0c: e58a0154     	str	r0, [r10, #0x154]
  24fd10: e3a00000     	mov	r0, #0
  24fd14: ee000a10     	vmov	s0, r0
  24fd18: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fd1c: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fd20: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fd24: ed8a0ad4     	vstr	s0, [r10, #848]
  24fd28: e3a00000     	mov	r0, #0
  24fd2c: ee000a10     	vmov	s0, r0
  24fd30: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fd34: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fd38: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fd3c: ed8a0ad5     	vstr	s0, [r10, #852]
  24fd40: e3a00000     	mov	r0, #0
  24fd44: ee000a10     	vmov	s0, r0
  24fd48: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fd4c: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fd50: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fd54: ed8a0ad6     	vstr	s0, [r10, #856]
  24fd58: e3a00000     	mov	r0, #0
  24fd5c: ee000a10     	vmov	s0, r0
  24fd60: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fd64: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fd68: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fd6c: ed8a0ad7     	vstr	s0, [r10, #860]
  24fd70: e3a00000     	mov	r0, #0
  24fd74: ee000a10     	vmov	s0, r0
  24fd78: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fd7c: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fd80: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fd84: ed8a0ad8     	vstr	s0, [r10, #864]
  24fd88: e3a00000     	mov	r0, #0
  24fd8c: ee000a10     	vmov	s0, r0
  24fd90: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fd94: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fd98: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fd9c: ed8a0ad9     	vstr	s0, [r10, #868]
  24fda0: e3a00000     	mov	r0, #0
  24fda4: ee000a10     	vmov	s0, r0
  24fda8: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fdac: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fdb0: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fdb4: ed8a0ada     	vstr	s0, [r10, #872]
  24fdb8: e3a00000     	mov	r0, #0
  24fdbc: ee000a10     	vmov	s0, r0
  24fdc0: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fdc4: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fdc8: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fdcc: ed8a0adb     	vstr	s0, [r10, #876]
  24fdd0: e3a00000     	mov	r0, #0
  24fdd4: ee000a10     	vmov	s0, r0
  24fdd8: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fddc: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fde0: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fde4: ed8a0adc     	vstr	s0, [r10, #880]
  24fde8: e3a00000     	mov	r0, #0
  24fdec: ee000a10     	vmov	s0, r0
  24fdf0: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fdf4: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fdf8: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fdfc: ed8a0add     	vstr	s0, [r10, #884]
  24fe00: e3a00000     	mov	r0, #0
  24fe04: ee000a10     	vmov	s0, r0
  24fe08: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fe0c: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fe10: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fe14: ed8a0ade     	vstr	s0, [r10, #888]
  24fe18: e3a00000     	mov	r0, #0
  24fe1c: ee000a10     	vmov	s0, r0
  24fe20: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fe24: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fe28: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fe2c: ed8a0adf     	vstr	s0, [r10, #892]
  24fe30: e3a00000     	mov	r0, #0
  24fe34: ee000a10     	vmov	s0, r0
  24fe38: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fe3c: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fe40: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fe44: ed8a0ae0     	vstr	s0, [r10, #896]
  24fe48: e3a00000     	mov	r0, #0
  24fe4c: ee000a10     	vmov	s0, r0
  24fe50: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fe54: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fe58: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fe5c: ed8a0ae1     	vstr	s0, [r10, #900]
  24fe60: e3a00000     	mov	r0, #0
  24fe64: ee000a10     	vmov	s0, r0
  24fe68: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fe6c: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fe70: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fe74: ed8a0ae2     	vstr	s0, [r10, #904]
  24fe78: e3a00000     	mov	r0, #0
  24fe7c: e58a038c     	str	r0, [r10, #0x38c]
  24fe80: e3a0000a     	mov	r0, #10
  24fe84: e58a0390     	str	r0, [r10, #0x390]
  24fe88: e3a00000     	mov	r0, #0
  24fe8c: ee000a10     	vmov	s0, r0
  24fe90: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fe94: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fe98: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fe9c: ed8a0ae5     	vstr	s0, [r10, #916]
  24fea0: e3e0000f     	mvn	r0, #15
  24fea4: ee000a10     	vmov	s0, r0
  24fea8: eeb80ac0     	vcvt.f32.s32	s0, s0
  24feac: eeb72ac0     	vcvt.f64.f32	d2, s0
  24feb0: eeb70bc2     	vcvt.f32.f64	s0, d2
  24feb4: ed8a0ae6     	vstr	s0, [r10, #920]
  24feb8: e3a00006     	mov	r0, #6
  24febc: ee000a10     	vmov	s0, r0
  24fec0: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fec4: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fec8: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fecc: ed8a0ae7     	vstr	s0, [r10, #924]
  24fed0: e3a00000     	mov	r0, #0
  24fed4: ee000a10     	vmov	s0, r0
  24fed8: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fedc: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fee0: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fee4: ed8a0ae9     	vstr	s0, [r10, #932]
  24fee8: ed9f2a00     	vldr	s4, [pc]                @ 0x24fef0 <start+0x243424>
  24feec: ea000000     	b	0x24fef4 <start+0x243428> @ imm = #0x0
  24fef0: 3f333333     	svclo	#0x333333
  24fef4: eeb72ac2     	vcvt.f64.f32	d2, s4
  24fef8: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fefc: ed8a0aea     	vstr	s0, [r10, #936]
  24ff00: e3a00001     	mov	r0, #1
  24ff04: ee000a10     	vmov	s0, r0
  24ff08: eeb80ac0     	vcvt.f32.s32	s0, s0
  24ff0c: eeb72ac0     	vcvt.f64.f32	d2, s0
  24ff10: eeb70bc2     	vcvt.f32.f64	s0, d2
  24ff14: ed8a0aeb     	vstr	s0, [r10, #940]
  24ff18: ed9f2a00     	vldr	s4, [pc]                @ 0x24ff20 <start+0x243454>
  24ff1c: ea000000     	b	0x24ff24 <start+0x243458> @ imm = #0x0
  24ff20: 3f34fdf4     	svclo	#0x34fdf4
  24ff24: eeb72ac2     	vcvt.f64.f32	d2, s4
  24ff28: eeb70bc2     	vcvt.f32.f64	s0, d2
  24ff2c: ed8a0aef     	vstr	s0, [r10, #956]
  24ff30: e3a00000     	mov	r0, #0
  24ff34: e5ca03c0     	strb	r0, [r10, #0x3c0]
  24ff38: e3a00005     	mov	r0, #5
  24ff3c: e58a03c4     	str	r0, [r10, #0x3c4]
  24ff40: e3a00000     	mov	r0, #0
  24ff44: ee000a10     	vmov	s0, r0
  24ff48: eeb80ac0     	vcvt.f32.s32	s0, s0
  24ff4c: eeb72ac0     	vcvt.f64.f32	d2, s0
  24ff50: eeb70bc2     	vcvt.f32.f64	s0, d2
  24ff54: ed8a0af2     	vstr	s0, [r10, #968]
  24ff58: ed9f2a00     	vldr	s4, [pc]                @ 0x24ff60 <start+0x243494>
  24ff5c: ea000000     	b	0x24ff64 <start+0x243498> @ imm = #0x0
  24ff60: 40666666     	rsbmi	r6, r6, r6, ror #12
  24ff64: eeb72ac2     	vcvt.f64.f32	d2, s4
  24ff68: eeb70bc2     	vcvt.f32.f64	s0, d2
  24ff6c: ed8a0af3     	vstr	s0, [r10, #972]
  24ff70: e3a00000     	mov	r0, #0
  24ff74: e5ca03d0     	strb	r0, [r10, #0x3d0]
  24ff78: e59f0000     	ldr	r0, [pc]                @ 0x24ff80 <start+0x2434b4>
  24ff7c: ea000000     	b	0x24ff84 <start+0x2434b8> @ imm = #0x0
  24ff80: 00500f68     	subseq	r0, r0, r8, ror #30
  24ff84: e79f0000     	ldr	r0, [pc, r0]
  24ff88: e58a016c     	str	r0, [r10, #0x16c]
  24ff8c: e59f0000     	ldr	r0, [pc]                @ 0x24ff94 <start+0x2434c8>
  24ff90: ea000000     	b	0x24ff98 <start+0x2434cc> @ imm = #0x0
  24ff94: 00500f28     	subseq	r0, r0, r8, lsr #30
  24ff98: e79f0000     	ldr	r0, [pc, r0]
  24ff9c: e58a0170     	str	r0, [r10, #0x170]
  24ffa0: e59f0000     	ldr	r0, [pc]                @ 0x24ffa8 <start+0x2434dc>
  24ffa4: ea000000     	b	0x24ffac <start+0x2434e0> @ imm = #0x0
  24ffa8: 00500f18     	subseq	r0, r0, r8, lsl pc
  24ffac: e79f0000     	ldr	r0, [pc, r0]
  24ffb0: e58a0174     	str	r0, [r10, #0x174]
  24ffb4: e59f0000     	ldr	r0, [pc]                @ 0x24ffbc <start+0x2434f0>
  24ffb8: ea000000     	b	0x24ffc0 <start+0x2434f4> @ imm = #0x0
  24ffbc: 00500f08     	subseq	r0, r0, r8, lsl #30
  24ffc0: e79f0000     	ldr	r0, [pc, r0]
  24ffc4: e58a0178     	str	r0, [r10, #0x178]
  24ffc8: e59f0000     	ldr	r0, [pc]                @ 0x24ffd0 <start+0x243504>
  24ffcc: ea000000     	b	0x24ffd4 <start+0x243508> @ imm = #0x0
  24ffd0: 00500ef8     	ldrsheq	r0, [r0], #-232
  24ffd4: e79f0000     	ldr	r0, [pc, r0]
  24ffd8: e58a017c     	str	r0, [r10, #0x17c]
  24ffdc: e3a00000     	mov	r0, #0
  24ffe0: e58a03d4     	str	r0, [r10, #0x3d4]
  24ffe4: e3a00001     	mov	r0, #1
  24ffe8: ee000a10     	vmov	s0, r0
  24ffec: eeb80ac0     	vcvt.f32.s32	s0, s0
  24fff0: eeb72ac0     	vcvt.f64.f32	d2, s0
  24fff4: eeb70bc2     	vcvt.f32.f64	s0, d2
  24fff8: ed8a0af9     	vstr	s0, [r10, #996]
  24fffc: ed9f2a00     	vldr	s4, [pc]                @ 0x250004 <start+0x243538>
  250000: ea000000     	b	0x250008 <start+0x24353c> @ imm = #0x0
  250004: 3dcccccd     	stcllo	p12, c12, [r12, #820]
  250008: eeb72ac2     	vcvt.f64.f32	d2, s4
  25000c: eeb70bc2     	vcvt.f32.f64	s0, d2
  250010: ed8a0afa     	vstr	s0, [r10, #1000]
  250014: ed9f2a00     	vldr	s4, [pc]                @ 0x25001c <start+0x243550>
  250018: ea000000     	b	0x250020 <start+0x243554> @ imm = #0x0
  25001c: 3fcccccd     	svclo	#0xcccccd
  250020: eeb72ac2     	vcvt.f64.f32	d2, s4
  250024: eeb70bc2     	vcvt.f32.f64	s0, d2
  250028: ed8a0afb     	vstr	s0, [r10, #1004]
  25002c: ed9f2a00     	vldr	s4, [pc]                @ 0x250034 <start+0x243568>
  250030: ea000000     	b	0x250038 <start+0x24356c> @ imm = #0x0
  250034: 3f000000     	svclo	#0x0
  250038: eeb72ac2     	vcvt.f64.f32	d2, s4
  25003c: eeb70bc2     	vcvt.f32.f64	s0, d2
  250040: ed8a0afc     	vstr	s0, [r10, #1008]
  250044: ed9f2a00     	vldr	s4, [pc]                @ 0x25004c <start+0x243580>
  250048: ea000000     	b	0x250050 <start+0x243584> @ imm = #0x0
  25004c: 3f400000     	svclo	#0x400000
  250050: eeb72ac2     	vcvt.f64.f32	d2, s4
  250054: eeb70bc2     	vcvt.f32.f64	s0, d2
  250058: ed8a0afd     	vstr	s0, [r10, #1012]
  25005c: ed9f2a00     	vldr	s4, [pc]                @ 0x250064 <start+0x243598>
  250060: ea000000     	b	0x250068 <start+0x24359c> @ imm = #0x0
  250064: 3f400000     	svclo	#0x400000
  250068: eeb72ac2     	vcvt.f64.f32	d2, s4
  25006c: eeb70bc2     	vcvt.f32.f64	s0, d2
  250070: ed8a0afe     	vstr	s0, [r10, #1016]
  250074: ed9f2a00     	vldr	s4, [pc]                @ 0x25007c <start+0x2435b0>
  250078: ea000000     	b	0x250080 <start+0x2435b4> @ imm = #0x0
  25007c: 3ff33333     	svclo	#0xf33333
  250080: eeb72ac2     	vcvt.f64.f32	d2, s4
  250084: eeb70bc2     	vcvt.f32.f64	s0, d2
  250088: ed8a0aff     	vstr	s0, [r10, #1020]
  25008c: ed9f2a00     	vldr	s4, [pc]                @ 0x250094 <start+0x2435c8>
  250090: ea000000     	b	0x250098 <start+0x2435cc> @ imm = #0x0
  250094: 3f99999a     	svclo	#0x99999a
  250098: eeb72ac2     	vcvt.f64.f32	d2, s4
  25009c: e28a0e40     	add	r0, r10, #64, #28
  2500a0: eeb70bc2     	vcvt.f32.f64	s0, d2
  2500a4: ed800a00     	vstr	s0, [r0]
  2500a8: e3a00000     	mov	r0, #0
  2500ac: ee000a10     	vmov	s0, r0
  2500b0: eeb80ac0     	vcvt.f32.s32	s0, s0
  2500b4: eeb72ac0     	vcvt.f64.f32	d2, s0
  2500b8: e28a0e40     	add	r0, r10, #64, #28
  2500bc: eeb70bc2     	vcvt.f32.f64	s0, d2
  2500c0: ed800a01     	vstr	s0, [r0, #4]
  2500c4: e3a00000     	mov	r0, #0
  2500c8: ee000a10     	vmov	s0, r0
  2500cc: eeb80ac0     	vcvt.f32.s32	s0, s0
  2500d0: eeb72ac0     	vcvt.f64.f32	d2, s0
  2500d4: e28a0e40     	add	r0, r10, #64, #28
  2500d8: eeb70bc2     	vcvt.f32.f64	s0, d2
  2500dc: ed800a02     	vstr	s0, [r0, #8]
  2500e0: e3a00000     	mov	r0, #0
  2500e4: ee000a10     	vmov	s0, r0
  2500e8: eeb80ac0     	vcvt.f32.s32	s0, s0
  2500ec: eeb72ac0     	vcvt.f64.f32	d2, s0
  2500f0: e28a0e40     	add	r0, r10, #64, #28
  2500f4: eeb70bc2     	vcvt.f32.f64	s0, d2
  2500f8: ed800a03     	vstr	s0, [r0, #12]
  2500fc: e3a00000     	mov	r0, #0
  250100: ee000a10     	vmov	s0, r0
  250104: eeb80ac0     	vcvt.f32.s32	s0, s0
  250108: eeb72ac0     	vcvt.f64.f32	d2, s0
  25010c: e28a0e40     	add	r0, r10, #64, #28
  250110: eeb70bc2     	vcvt.f32.f64	s0, d2
  250114: ed800a04     	vstr	s0, [r0, #16]
  250118: e3a00000     	mov	r0, #0
  25011c: e58a041c     	str	r0, [r10, #0x41c]
  250120: e3a00000     	mov	r0, #0
  250124: e58a0420     	str	r0, [r10, #0x420]
  250128: e3a00000     	mov	r0, #0
  25012c: ee000a10     	vmov	s0, r0
  250130: eeb80ac0     	vcvt.f32.s32	s0, s0
  250134: eeb72ac0     	vcvt.f64.f32	d2, s0
  250138: e28a0e40     	add	r0, r10, #64, #28
  25013c: eeb70bc2     	vcvt.f32.f64	s0, d2
  250140: ed800a09     	vstr	s0, [r0, #36]
  250144: e28bd014     	add	sp, r11, #20
  250148: e8bd0d00     	pop	{r8, r10, r11}
  25014c: e59d7008     	ldr	r7, [sp, #0x8]
  250150: e89da000     	ldm	sp, {sp, pc}
