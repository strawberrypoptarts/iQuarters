
/Users/tomato/Documents/Codex/iQuarters/Recovery/native/iquarters-armv7:	file format mach-o arm

Disassembly of section __TEXT,__text:

0000cacc <start>:
  2522b0: e1a0c00d     	mov	r12, sp
  2522b4: e92d4080     	push	{r7, lr}
  2522b8: e1a0700d     	mov	r7, sp
  2522bc: e92d5d40     	push	{r6, r8, r10, r11, r12, lr}
  2522c0: e24ddf66     	sub	sp, sp, #408
  2522c4: e1a0b00d     	mov	r11, sp
  2522c8: e1a0a000     	mov	r10, r0
  2522cc: e3a00000     	mov	r0, #0
  2522d0: e58b0024     	str	r0, [r11, #0x24]
  2522d4: e3a00000     	mov	r0, #0
  2522d8: e58b0028     	str	r0, [r11, #0x28]
  2522dc: e3a00000     	mov	r0, #0
  2522e0: e58b002c     	str	r0, [r11, #0x2c]
  2522e4: e3a00000     	mov	r0, #0
  2522e8: e58b0034     	str	r0, [r11, #0x34]
  2522ec: e3a00000     	mov	r0, #0
  2522f0: e58b0038     	str	r0, [r11, #0x38]
  2522f4: e3a00000     	mov	r0, #0
  2522f8: e58b003c     	str	r0, [r11, #0x3c]
  2522fc: e3a00000     	mov	r0, #0
  252300: e58b0044     	str	r0, [r11, #0x44]
  252304: e3a00000     	mov	r0, #0
  252308: e58b0048     	str	r0, [r11, #0x48]
  25230c: e3a00000     	mov	r0, #0
  252310: e58b004c     	str	r0, [r11, #0x4c]
  252314: e3a00000     	mov	r0, #0
  252318: e58b0054     	str	r0, [r11, #0x54]
  25231c: e3a00000     	mov	r0, #0
  252320: e58b0058     	str	r0, [r11, #0x58]
  252324: e3a00000     	mov	r0, #0
  252328: e58b005c     	str	r0, [r11, #0x5c]
  25232c: e3a00000     	mov	r0, #0
  252330: e58b0060     	str	r0, [r11, #0x60]
  252334: e3a00000     	mov	r0, #0
  252338: e58b0064     	str	r0, [r11, #0x64]
  25233c: e3a00000     	mov	r0, #0
  252340: e58b0068     	str	r0, [r11, #0x68]
  252344: e3a00000     	mov	r0, #0
  252348: e58b0070     	str	r0, [r11, #0x70]
  25234c: e3a00000     	mov	r0, #0
  252350: e58b0074     	str	r0, [r11, #0x74]
  252354: e3a00000     	mov	r0, #0
  252358: e58b0078     	str	r0, [r11, #0x78]
  25235c: e3a00000     	mov	r0, #0
  252360: e58b0080     	str	r0, [r11, #0x80]
  252364: e3a00000     	mov	r0, #0
  252368: e58b0084     	str	r0, [r11, #0x84]
  25236c: e3a00000     	mov	r0, #0
  252370: e58b0088     	str	r0, [r11, #0x88]
  252374: e3a00000     	mov	r0, #0
  252378: e58b0090     	str	r0, [r11, #0x90]
  25237c: e3a00000     	mov	r0, #0
  252380: e58b0094     	str	r0, [r11, #0x94]
  252384: e3a00000     	mov	r0, #0
  252388: e58b0098     	str	r0, [r11, #0x98]
  25238c: e3a00000     	mov	r0, #0
  252390: e58b00a0     	str	r0, [r11, #0xa0]
  252394: e3a00000     	mov	r0, #0
  252398: e58b00a4     	str	r0, [r11, #0xa4]
  25239c: e3a00000     	mov	r0, #0
  2523a0: e58b00a8     	str	r0, [r11, #0xa8]
  2523a4: e59f0000     	ldr	r0, [pc]                @ 0x2523ac <start+0x2458e0>
  2523a8: ea000000     	b	0x2523b0 <start+0x2458e4> @ imm = #0x0
  2523ac: 004febd8     	ldrdeq	lr, pc, [pc], #-184
  2523b0: e79f0000     	ldr	r0, [pc, r0]
  2523b4: e5900000     	ldr	r0, [r0]
  2523b8: e3500001     	cmp	r0, #1
  2523bc: 13a00000     	movne	r0, #0
  2523c0: 03a00001     	moveq	r0, #1
  2523c4: e3500000     	cmp	r0, #0
  2523c8: 0a000002     	beq	0x2523d8 <start+0x24590c> @ imm = #0x8
  2523cc: e1a0000a     	mov	r0, r10
  2523d0: e59ae000     	ldr	lr, [r10]
  2523d4: ebfffe7f     	bl	0x251dd8 <start+0x24530c> @ imm = #-0x604
  2523d8: e59f0000     	ldr	r0, [pc]                @ 0x2523e0 <start+0x245914>
  2523dc: ea000000     	b	0x2523e4 <start+0x245918> @ imm = #0x0
  2523e0: 004fe9e8     	subeq	lr, pc, r8, ror #19
  2523e4: e79f0000     	ldr	r0, [pc, r0]
  2523e8: e5d00000     	ldrb	r0, [r0]
  2523ec: e3500001     	cmp	r0, #1
  2523f0: 13a00000     	movne	r0, #0
  2523f4: 03a00001     	moveq	r0, #1
  2523f8: e3500000     	cmp	r0, #0
  2523fc: 0a00006e     	beq	0x2525bc <start+0x245af0> @ imm = #0x1b8
  252400: e59f0000     	ldr	r0, [pc]                @ 0x252408 <start+0x24593c>
  252404: ea000000     	b	0x25240c <start+0x245940> @ imm = #0x0
  252408: 004feb7c     	subeq	lr, pc, r12, ror r11
  25240c: e79f0000     	ldr	r0, [pc, r0]
  252410: e5900000     	ldr	r0, [r0]
  252414: e3500001     	cmp	r0, #1
  252418: 13a00000     	movne	r0, #0
  25241c: 03a00001     	moveq	r0, #1
  252420: e3500000     	cmp	r0, #0
  252424: 0a000064     	beq	0x2525bc <start+0x245af0> @ imm = #0x190
  252428: e5da03c0     	ldrb	r0, [r10, #0x3c0]
  25242c: e3500000     	cmp	r0, #0
  252430: 1a000061     	bne	0x2525bc <start+0x245af0> @ imm = #0x184
  252434: e59a0304     	ldr	r0, [r10, #0x304]
  252438: e59a1348     	ldr	r1, [r10, #0x348]
  25243c: e1500001     	cmp	r0, r1
  252440: e3a00000     	mov	r0, #0
  252444: b3a00001     	movlt	r0, #1
  252448: e3500000     	cmp	r0, #0
  25244c: 0a00005a     	beq	0x2525bc <start+0x245af0> @ imm = #0x168
  252450: e59a6304     	ldr	r6, [r10, #0x304]
  252454: e59a2118     	ldr	r2, [r10, #0x118]
  252458: e1a00002     	mov	r0, r2
  25245c: e1a01006     	mov	r1, r6
  252460: e5922000     	ldr	r2, [r2]
  252464: e1a0e00f     	mov	lr, pc
  252468: e592f050     	ldr	pc, [r2, #0x50]
  25246c: e1a06000     	mov	r6, r0
  252470: e3560000     	cmp	r6, #0
  252474: 0a000009     	beq	0x2524a0 <start+0x2459d4> @ imm = #0x24
  252478: e5960000     	ldr	r0, [r6]
  25247c: e5900000     	ldr	r0, [r0]
  252480: e5900008     	ldr	r0, [r0, #0x8]
  252484: e5900004     	ldr	r0, [r0, #0x4]
  252488: e59f1000     	ldr	r1, [pc]                @ 0x252490 <start+0x2459c4>
  25248c: ea000000     	b	0x252494 <start+0x2459c8> @ imm = #0x0
  252490: 004feb3c     	subeq	lr, pc, r12, lsr r11
  252494: e79f1001     	ldr	r1, [pc, r1]
  252498: e1500001     	cmp	r0, r1
  25249c: 1b000219     	blne	0x252d08 <start+0x24623c> @ imm = #0x864
  2524a0: e58b6010     	str	r6, [r11, #0x10]
  2524a4: eb00fc7d     	bl	0x2916a0 <start+0x284bd4> @ imm = #0x3f1f4 // System.Single UnityEngine.Time::get_time()
  2524a8: ee020a10     	vmov	s4, r0
  2524ac: eeb72ac2     	vcvt.f64.f32	d2, s4
  2524b0: ed9a0af2     	vldr	s0, [r10, #968]
  2524b4: eeb73ac0     	vcvt.f64.f32	d3, s0
  2524b8: ee322b43     	vsub.f64	d2, d2, d3
  2524bc: eeb70bc2     	vcvt.f32.f64	s0, d2
  2524c0: ed8a0ac2     	vstr	s0, [r10, #776]
  2524c4: ed9a0ac2     	vldr	s0, [r10, #776]
  2524c8: eeb72ac0     	vcvt.f64.f32	d2, s0
  2524cc: ed960a03     	vldr	s0, [r6, #12]
  2524d0: eeb73ac0     	vcvt.f64.f32	d3, s0
  2524d4: eeb43b42     	vcmp.f64	d3, d2
  2524d8: eef1fa10     	vmrs	APSR_nzcv, fpscr
  2524dc: e3a00000     	mov	r0, #0
  2524e0: 43a00001     	movmi	r0, #1
  2524e4: e3500000     	cmp	r0, #0
  2524e8: 0a000033     	beq	0x2525bc <start+0x245af0> @ imm = #0xcc
  2524ec: e1a0000a     	mov	r0, r10
  2524f0: e59ae000     	ldr	lr, [r10]
  2524f4: eb00fc85     	bl	0x291710 <start+0x284c44> @ imm = #0x3f214 // UnityEngine.Transform UnityEngine.Component::get_transform()
  2524f8: e1a02000     	mov	r2, r0
  2524fc: e28b00c8     	add	r0, r11, #200
  252500: e1a01002     	mov	r1, r2
  252504: e592e000     	ldr	lr, [r2]
  252508: eb00fc74     	bl	0x2916e0 <start+0x284c14> @ imm = #0x3f1d0 // UnityEngine.Vector3 UnityEngine.Transform::get_position()
  25250c: e1a0000a     	mov	r0, r10
  252510: e59b10c8     	ldr	r1, [r11, #0xc8]
  252514: e59b20cc     	ldr	r2, [r11, #0xcc]
  252518: e59b30d0     	ldr	r3, [r11, #0xd0]
  25251c: e59ae000     	ldr	lr, [r10]
  252520: ebfffe7d     	bl	0x251f1c <start+0x245450> @ imm = #-0x60c
  252524: e59a0304     	ldr	r0, [r10, #0x304]
  252528: e59a1348     	ldr	r1, [r10, #0x348]
  25252c: e3a02001     	mov	r2, #1
  252530: e0511002     	subs	r1, r1, r2
  252534: 6b0001ef     	blvs	0x252cf8 <start+0x24622c> @ imm = #0x7bc
  252538: e1500001     	cmp	r0, r1
  25253c: e3a00000     	mov	r0, #0
  252540: b3a00001     	movlt	r0, #1
  252544: e3500000     	cmp	r0, #0
  252548: 0a000016     	beq	0x2525a8 <start+0x245adc> @ imm = #0x58
  25254c: e59f0000     	ldr	r0, [pc]                @ 0x252554 <start+0x245a88>
  252550: ea000000     	b	0x252558 <start+0x245a8c> @ imm = #0x0
  252554: 004fea7c     	subeq	lr, pc, r12, ror r10
  252558: e79f0000     	ldr	r0, [pc, r0]
  25255c: e5900000     	ldr	r0, [r0]
  252560: e3a01001     	mov	r1, #1
  252564: e0901001     	adds	r1, r0, r1
  252568: 6b0001e2     	blvs	0x252cf8 <start+0x24622c> @ imm = #0x788
  25256c: e59f0000     	ldr	r0, [pc]                @ 0x252574 <start+0x245aa8>
  252570: ea000000     	b	0x252578 <start+0x245aac> @ imm = #0x0
  252574: 004fea5c     	subeq	lr, pc, r12, asr r10
  252578: e79f0000     	ldr	r0, [pc, r0]
  25257c: e5801000     	str	r1, [r0]
  252580: e59f0000     	ldr	r0, [pc]                @ 0x252588 <start+0x245abc>
  252584: ea000000     	b	0x25258c <start+0x245ac0> @ imm = #0x0
  252588: 004fea48     	subeq	lr, pc, r8, asr #20
  25258c: e79f0000     	ldr	r0, [pc, r0]
  252590: e5901000     	ldr	r1, [r0]
  252594: e59f0000     	ldr	r0, [pc]                @ 0x25259c <start+0x245ad0>
  252598: ea000000     	b	0x2525a0 <start+0x245ad4> @ imm = #0x0
  25259c: 004fea38     	subeq	lr, pc, r8, lsr r10
  2525a0: e79f0000     	ldr	r0, [pc, r0]
  2525a4: e5801000     	str	r1, [r0]
  2525a8: e59a0304     	ldr	r0, [r10, #0x304]
  2525ac: e3a01001     	mov	r1, #1
  2525b0: e0900001     	adds	r0, r0, r1
  2525b4: 6b0001cf     	blvs	0x252cf8 <start+0x24622c> @ imm = #0x73c
  2525b8: e58a0304     	str	r0, [r10, #0x304]
  2525bc: e59f0000     	ldr	r0, [pc]                @ 0x2525c4 <start+0x245af8>
  2525c0: ea000000     	b	0x2525c8 <start+0x245afc> @ imm = #0x0
  2525c4: 004fe9c0     	subeq	lr, pc, r0, asr #19
  2525c8: e79f0000     	ldr	r0, [pc, r0]
  2525cc: e5900000     	ldr	r0, [r0]
  2525d0: e59f1000     	ldr	r1, [pc]                @ 0x2525d8 <start+0x245b0c>
  2525d4: ea000000     	b	0x2525dc <start+0x245b10> @ imm = #0x0
  2525d8: 004fe948     	subeq	lr, pc, r8, asr #18
  2525dc: e79f1001     	ldr	r1, [pc, r1]
  2525e0: e5911000     	ldr	r1, [r1]
  2525e4: e1500001     	cmp	r0, r1
  2525e8: 13a00000     	movne	r0, #0
  2525ec: 03a00001     	moveq	r0, #1
  2525f0: e3500000     	cmp	r0, #0
  2525f4: 0a0001bb     	beq	0x252ce8 <start+0x24621c> @ imm = #0x6ec
  2525f8: e59a038c     	ldr	r0, [r10, #0x38c]
  2525fc: e59a13c4     	ldr	r1, [r10, #0x3c4]
  252600: e1500001     	cmp	r0, r1
  252604: 13a00000     	movne	r0, #0
  252608: 03a00001     	moveq	r0, #1
  25260c: e3500000     	cmp	r0, #0
  252610: 0a000013     	beq	0x252664 <start+0x245b98> @ imm = #0x4c
  252614: e59f0000     	ldr	r0, [pc]                @ 0x25261c <start+0x245b50>
  252618: ea000000     	b	0x252620 <start+0x245b54> @ imm = #0x0
  25261c: 004fe7ac     	subeq	lr, pc, r12, lsr #15
  252620: e79f0000     	ldr	r0, [pc, r0]
  252624: e5d00000     	ldrb	r0, [r0]
  252628: e3500000     	cmp	r0, #0
  25262c: 1a000006     	bne	0x25264c <start+0x245b80> @ imm = #0x18
  252630: e59f0000     	ldr	r0, [pc]                @ 0x252638 <start+0x245b6c>
  252634: ea000000     	b	0x25263c <start+0x245b70> @ imm = #0x0
  252638: 004fe3ec     	subeq	lr, pc, r12, ror #7
  25263c: e79f0000     	ldr	r0, [pc, r0]
  252640: e3a01001     	mov	r1, #1
  252644: e5801000     	str	r1, [r0]
  252648: ea000005     	b	0x252664 <start+0x245b98> @ imm = #0x14
  25264c: e59f0000     	ldr	r0, [pc]                @ 0x252654 <start+0x245b88>
  252650: ea000000     	b	0x252658 <start+0x245b8c> @ imm = #0x0
  252654: 004fe3d0     	ldrdeq	lr, pc, [pc], #-48
  252658: e79f0000     	ldr	r0, [pc, r0]
  25265c: e3a01002     	mov	r1, #2
  252660: e5801000     	str	r1, [r0]
  252664: e59a038c     	ldr	r0, [r10, #0x38c]
  252668: e3a01001     	mov	r1, #1
  25266c: e0500001     	subs	r0, r0, r1
  252670: 6b0001a0     	blvs	0x252cf8 <start+0x24622c> @ imm = #0x680
  252674: e58a038c     	str	r0, [r10, #0x38c]
  252678: e3500000     	cmp	r0, #0
  25267c: e3a00000     	mov	r0, #0
  252680: b3a00001     	movlt	r0, #1
  252684: e3500000     	cmp	r0, #0
  252688: 0a000174     	beq	0x252c60 <start+0x246194> @ imm = #0x5d0
  25268c: e1a0000a     	mov	r0, r10
  252690: e59ae000     	ldr	lr, [r10]
  252694: eb00fed5     	bl	0x2921f0 <start+0x285724> @ imm = #0x3fb54 // UnityEngine.Rigidbody UnityEngine.Component::get_rigidbody()
  252698: e1a02000     	mov	r2, r0
  25269c: e28b0060     	add	r0, r11, #96
  2526a0: e1a01002     	mov	r1, r2
  2526a4: e592e000     	ldr	lr, [r2]
  2526a8: eb00fea0     	bl	0x292130 <start+0x285664> @ imm = #0x3fa80 // UnityEngine.Vector3 UnityEngine.Rigidbody::get_position()
  2526ac: ed9b0a19     	vldr	s0, [r11, #100]
  2526b0: eeb72ac0     	vcvt.f64.f32	d2, s0
  2526b4: e3a00001     	mov	r0, #1
  2526b8: ee000a10     	vmov	s0, r0
  2526bc: eeb80ac0     	vcvt.f32.s32	s0, s0
  2526c0: eeb73ac0     	vcvt.f64.f32	d3, s0
  2526c4: ee322b03     	vadd.f64	d2, d2, d3
  2526c8: eeb02b42     	vmov.f64	d2, d2
  2526cc: eeb02b42     	vmov.f64	d2, d2
  2526d0: eeb70bc2     	vcvt.f32.f64	s0, d2
  2526d4: ed8b0a08     	vstr	s0, [r11, #32]
  2526d8: e1a0000a     	mov	r0, r10
  2526dc: e59ae000     	ldr	lr, [r10]
  2526e0: eb00fec2     	bl	0x2921f0 <start+0x285724> @ imm = #0x3fb08 // UnityEngine.Rigidbody UnityEngine.Component::get_rigidbody()
  2526e4: e1a02000     	mov	r2, r0
  2526e8: e28b00d4     	add	r0, r11, #212
  2526ec: e1a01002     	mov	r1, r2
  2526f0: e592e000     	ldr	lr, [r2]
  2526f4: eb00fe8d     	bl	0x292130 <start+0x285664> @ imm = #0x3fa34 // UnityEngine.Vector3 UnityEngine.Rigidbody::get_position()
  2526f8: e59b00d4     	ldr	r0, [r11, #0xd4]
  2526fc: e58b0024     	str	r0, [r11, #0x24]
  252700: e59b00d8     	ldr	r0, [r11, #0xd8]
  252704: e58b0028     	str	r0, [r11, #0x28]
  252708: e59b00dc     	ldr	r0, [r11, #0xdc]
  25270c: e58b002c     	str	r0, [r11, #0x2c]
  252710: ed9b0a08     	vldr	s0, [r11, #32]
  252714: eeb72ac0     	vcvt.f64.f32	d2, s0
  252718: eeb03b42     	vmov.f64	d3, d2
  25271c: eeb03b43     	vmov.f64	d3, d3
  252720: eeb02b43     	vmov.f64	d2, d3
  252724: eeb02b42     	vmov.f64	d2, d2
  252728: eeb03b43     	vmov.f64	d3, d3
  25272c: eeb70bc3     	vcvt.f32.f64	s0, d3
  252730: ed8b0a1b     	vstr	s0, [r11, #108]
  252734: eeb70bc2     	vcvt.f32.f64	s0, d2
  252738: ed8b0a0a     	vstr	s0, [r11, #40]
  25273c: e1a0000a     	mov	r0, r10
  252740: e59ae000     	ldr	lr, [r10]
  252744: eb00fea9     	bl	0x2921f0 <start+0x285724> @ imm = #0x3faa4 // UnityEngine.Rigidbody UnityEngine.Component::get_rigidbody()
  252748: e1a0c000     	mov	r12, r0
  25274c: e59b0024     	ldr	r0, [r11, #0x24]
  252750: e58b00e0     	str	r0, [r11, #0xe0]
  252754: e59b0028     	ldr	r0, [r11, #0x28]
  252758: e58b00e4     	str	r0, [r11, #0xe4]
  25275c: e59b002c     	ldr	r0, [r11, #0x2c]
  252760: e58b00e8     	str	r0, [r11, #0xe8]
  252764: e59b00e0     	ldr	r0, [r11, #0xe0]
  252768: e58b00ec     	str	r0, [r11, #0xec]
  25276c: e59b00e4     	ldr	r0, [r11, #0xe4]
  252770: e58b00f0     	str	r0, [r11, #0xf0]
  252774: e59b00e8     	ldr	r0, [r11, #0xe8]
  252778: e58b00f4     	str	r0, [r11, #0xf4]
  25277c: e59b00e0     	ldr	r0, [r11, #0xe0]
  252780: e58b0070     	str	r0, [r11, #0x70]
  252784: e59b00e4     	ldr	r0, [r11, #0xe4]
  252788: e58b0074     	str	r0, [r11, #0x74]
  25278c: e59b00e8     	ldr	r0, [r11, #0xe8]
  252790: e58b0078     	str	r0, [r11, #0x78]
  252794: e1a0000c     	mov	r0, r12
  252798: e59b10ec     	ldr	r1, [r11, #0xec]
  25279c: e59b20f0     	ldr	r2, [r11, #0xf0]
  2527a0: e59b30f4     	ldr	r3, [r11, #0xf4]
  2527a4: e59ce000     	ldr	lr, [r12]
  2527a8: eb00fe6c     	bl	0x292160 <start+0x285694> @ imm = #0x3f9b0 // System.Void UnityEngine.Rigidbody::set_position(UnityEngine.Vector3)
  2527ac: e59f0000     	ldr	r0, [pc]                @ 0x2527b4 <start+0x245ce8>
  2527b0: ea000000     	b	0x2527b8 <start+0x245cec> @ imm = #0x0
  2527b4: 004fe620     	subeq	lr, pc, r0, lsr #12
  2527b8: e79f0000     	ldr	r0, [pc, r0]
  2527bc: ed900a00     	vldr	s0, [r0]
  2527c0: eeb72ac0     	vcvt.f64.f32	d2, s0
  2527c4: ed9f3a00     	vldr	s6, [pc]                @ 0x2527cc <start+0x245d00>
  2527c8: ea000000     	b	0x2527d0 <start+0x245d04> @ imm = #0x0
  2527cc: 3c8efa35     	vstmialo	lr, {s30, s31}
  2527d0: eeb73ac3     	vcvt.f64.f32	d3, s6
  2527d4: ee222b03     	vmul.f64	d2, d2, d3
  2527d8: eeb70bc2     	vcvt.f32.f64	s0, d2
  2527dc: ed8b0a05     	vstr	s0, [r11, #20]
  2527e0: e59f0000     	ldr	r0, [pc]                @ 0x2527e8 <start+0x245d1c>
  2527e4: ea000000     	b	0x2527ec <start+0x245d20> @ imm = #0x0
  2527e8: 004fe5e4     	subeq	lr, pc, r4, ror #11
  2527ec: e79f0000     	ldr	r0, [pc, r0]
  2527f0: ed900a00     	vldr	s0, [r0]
  2527f4: eeb72ac0     	vcvt.f64.f32	d2, s0
  2527f8: eeb70bc2     	vcvt.f32.f64	s0, d2
  2527fc: ed8b0a06     	vstr	s0, [r11, #24]
  252800: e59f0000     	ldr	r0, [pc]                @ 0x252808 <start+0x245d3c>
  252804: ea000000     	b	0x25280c <start+0x245d40> @ imm = #0x0
  252808: 004fe70c     	subeq	lr, pc, r12, lsl #14
  25280c: e79f0000     	ldr	r0, [pc, r0]
  252810: ed900a00     	vldr	s0, [r0]
  252814: eeb72ac0     	vcvt.f64.f32	d2, s0
  252818: ed9b0a06     	vldr	s0, [r11, #24]
  25281c: eeb73ac0     	vcvt.f64.f32	d3, s0
  252820: ee222b03     	vmul.f64	d2, d2, d3
  252824: eeb70bc2     	vcvt.f32.f64	s0, d2
  252828: ed8b0a07     	vstr	s0, [r11, #28]
  25282c: ed9b0a07     	vldr	s0, [r11, #28]
  252830: eeb72ac0     	vcvt.f64.f32	d2, s0
  252834: ed8b2b64     	vstr	d2, [r11, #400]
  252838: ed9b0a05     	vldr	s0, [r11, #20]
  25283c: eeb72ac0     	vcvt.f64.f32	d2, s0
  252840: eeb70bc2     	vcvt.f32.f64	s0, d2
  252844: ed0d0a02     	vstr	s0, [sp, #-8]
  252848: e51d0008     	ldr	r0, [sp, #-0x8]
  25284c: eb00feaf     	bl	0x292310 <start+0x285844> @ imm = #0x3fabc // System.Single UnityEngine.Mathf::Sin(System.Single)
  252850: ee030a10     	vmov	s6, r0
  252854: eeb73ac3     	vcvt.f64.f32	d3, s6
  252858: ed9b2b64     	vldr	d2, [r11, #400]
  25285c: ee222b03     	vmul.f64	d2, d2, d3
  252860: eeb02b42     	vmov.f64	d2, d2
  252864: eeb02b42     	vmov.f64	d2, d2
  252868: eeb70bc2     	vcvt.f32.f64	s0, d2
  25286c: ed8b0a0c     	vstr	s0, [r11, #48]
  252870: e1a0000a     	mov	r0, r10
  252874: e59ae000     	ldr	lr, [r10]
  252878: eb00fe5c     	bl	0x2921f0 <start+0x285724> @ imm = #0x3f970 // UnityEngine.Rigidbody UnityEngine.Component::get_rigidbody()
  25287c: e1a02000     	mov	r2, r0
  252880: e28b00f8     	add	r0, r11, #248
  252884: e1a01002     	mov	r1, r2
  252888: e592e000     	ldr	lr, [r2]
  25288c: eb00fb73     	bl	0x291660 <start+0x284b94> @ imm = #0x3edcc // UnityEngine.Vector3 UnityEngine.Rigidbody::get_velocity()
  252890: e59b00f8     	ldr	r0, [r11, #0xf8]
  252894: e58b0034     	str	r0, [r11, #0x34]
  252898: e59b00fc     	ldr	r0, [r11, #0xfc]
  25289c: e58b0038     	str	r0, [r11, #0x38]
  2528a0: e59b0100     	ldr	r0, [r11, #0x100]
  2528a4: e58b003c     	str	r0, [r11, #0x3c]
  2528a8: ed9b0a0c     	vldr	s0, [r11, #48]
  2528ac: eeb72ac0     	vcvt.f64.f32	d2, s0
  2528b0: eeb03b42     	vmov.f64	d3, d2
  2528b4: eeb03b43     	vmov.f64	d3, d3
  2528b8: eeb02b43     	vmov.f64	d2, d3
  2528bc: eeb02b42     	vmov.f64	d2, d2
  2528c0: eeb03b43     	vmov.f64	d3, d3
  2528c4: eeb70bc3     	vcvt.f32.f64	s0, d3
  2528c8: ed8b0a1f     	vstr	s0, [r11, #124]
  2528cc: eeb70bc2     	vcvt.f32.f64	s0, d2
  2528d0: ed8b0a0e     	vstr	s0, [r11, #56]
  2528d4: e1a0000a     	mov	r0, r10
  2528d8: e59ae000     	ldr	lr, [r10]
  2528dc: eb00fe43     	bl	0x2921f0 <start+0x285724> @ imm = #0x3f90c // UnityEngine.Rigidbody UnityEngine.Component::get_rigidbody()
  2528e0: e1a0c000     	mov	r12, r0
  2528e4: e59b0034     	ldr	r0, [r11, #0x34]
  2528e8: e58b0104     	str	r0, [r11, #0x104]
  2528ec: e59b0038     	ldr	r0, [r11, #0x38]
  2528f0: e58b0108     	str	r0, [r11, #0x108]
  2528f4: e59b003c     	ldr	r0, [r11, #0x3c]
  2528f8: e58b010c     	str	r0, [r11, #0x10c]
  2528fc: e59b0104     	ldr	r0, [r11, #0x104]
  252900: e58b0110     	str	r0, [r11, #0x110]
  252904: e59b0108     	ldr	r0, [r11, #0x108]
  252908: e58b0114     	str	r0, [r11, #0x114]
  25290c: e59b010c     	ldr	r0, [r11, #0x10c]
  252910: e58b0118     	str	r0, [r11, #0x118]
  252914: e59b0104     	ldr	r0, [r11, #0x104]
  252918: e58b0080     	str	r0, [r11, #0x80]
  25291c: e59b0108     	ldr	r0, [r11, #0x108]
  252920: e58b0084     	str	r0, [r11, #0x84]
  252924: e59b010c     	ldr	r0, [r11, #0x10c]
  252928: e58b0088     	str	r0, [r11, #0x88]
  25292c: e1a0000c     	mov	r0, r12
  252930: e59b1110     	ldr	r1, [r11, #0x110]
  252934: e59b2114     	ldr	r2, [r11, #0x114]
  252938: e59b3118     	ldr	r3, [r11, #0x118]
  25293c: e59ce000     	ldr	lr, [r12]
  252940: eb00fb4a     	bl	0x291670 <start+0x284ba4> @ imm = #0x3ed28 // System.Void UnityEngine.Rigidbody::set_velocity(UnityEngine.Vector3)
  252944: ed9b0a07     	vldr	s0, [r11, #28]
  252948: eeb72ac0     	vcvt.f64.f32	d2, s0
  25294c: ed8b2b62     	vstr	d2, [r11, #392]
  252950: ed9b0a05     	vldr	s0, [r11, #20]
  252954: eeb72ac0     	vcvt.f64.f32	d2, s0
  252958: eeb70bc2     	vcvt.f32.f64	s0, d2
  25295c: ed0d0a02     	vstr	s0, [sp, #-8]
  252960: e51d0008     	ldr	r0, [sp, #-0x8]
  252964: eb00fe6d     	bl	0x292320 <start+0x285854> @ imm = #0x3f9b4 // System.Single UnityEngine.Mathf::Cos(System.Single)
  252968: ee030a10     	vmov	s6, r0
  25296c: eeb73ac3     	vcvt.f64.f32	d3, s6
  252970: ed9b2b62     	vldr	d2, [r11, #392]
  252974: ee222b03     	vmul.f64	d2, d2, d3
  252978: eeb02b42     	vmov.f64	d2, d2
  25297c: eeb02b42     	vmov.f64	d2, d2
  252980: eeb70bc2     	vcvt.f32.f64	s0, d2
  252984: ed8b0a10     	vstr	s0, [r11, #64]
  252988: e1a0000a     	mov	r0, r10
  25298c: e59ae000     	ldr	lr, [r10]
  252990: eb00fe16     	bl	0x2921f0 <start+0x285724> @ imm = #0x3f858 // UnityEngine.Rigidbody UnityEngine.Component::get_rigidbody()
  252994: e1a02000     	mov	r2, r0
  252998: e28b0f47     	add	r0, r11, #284
  25299c: e1a01002     	mov	r1, r2
  2529a0: e592e000     	ldr	lr, [r2]
  2529a4: eb00fb2d     	bl	0x291660 <start+0x284b94> @ imm = #0x3ecb4 // UnityEngine.Vector3 UnityEngine.Rigidbody::get_velocity()
  2529a8: e59b011c     	ldr	r0, [r11, #0x11c]
  2529ac: e58b0044     	str	r0, [r11, #0x44]
  2529b0: e59b0120     	ldr	r0, [r11, #0x120]
  2529b4: e58b0048     	str	r0, [r11, #0x48]
  2529b8: e59b0124     	ldr	r0, [r11, #0x124]
  2529bc: e58b004c     	str	r0, [r11, #0x4c]
  2529c0: ed9b0a10     	vldr	s0, [r11, #64]
  2529c4: eeb72ac0     	vcvt.f64.f32	d2, s0
  2529c8: eeb03b42     	vmov.f64	d3, d2
  2529cc: eeb03b43     	vmov.f64	d3, d3
  2529d0: eeb02b43     	vmov.f64	d2, d3
  2529d4: eeb02b42     	vmov.f64	d2, d2
  2529d8: eeb03b43     	vmov.f64	d3, d3
  2529dc: eeb70bc3     	vcvt.f32.f64	s0, d3
  2529e0: ed8b0a23     	vstr	s0, [r11, #140]
  2529e4: eeb70bc2     	vcvt.f32.f64	s0, d2
  2529e8: ed8b0a13     	vstr	s0, [r11, #76]
  2529ec: e1a0000a     	mov	r0, r10
  2529f0: e59ae000     	ldr	lr, [r10]
  2529f4: eb00fdfd     	bl	0x2921f0 <start+0x285724> @ imm = #0x3f7f4 // UnityEngine.Rigidbody UnityEngine.Component::get_rigidbody()
  2529f8: e1a0c000     	mov	r12, r0
  2529fc: e59b0044     	ldr	r0, [r11, #0x44]
  252a00: e58b0128     	str	r0, [r11, #0x128]
  252a04: e59b0048     	ldr	r0, [r11, #0x48]
  252a08: e58b012c     	str	r0, [r11, #0x12c]
  252a0c: e59b004c     	ldr	r0, [r11, #0x4c]
  252a10: e58b0130     	str	r0, [r11, #0x130]
  252a14: e59b0128     	ldr	r0, [r11, #0x128]
  252a18: e58b0134     	str	r0, [r11, #0x134]
  252a1c: e59b012c     	ldr	r0, [r11, #0x12c]
  252a20: e58b0138     	str	r0, [r11, #0x138]
  252a24: e59b0130     	ldr	r0, [r11, #0x130]
  252a28: e58b013c     	str	r0, [r11, #0x13c]
  252a2c: e59b0128     	ldr	r0, [r11, #0x128]
  252a30: e58b0090     	str	r0, [r11, #0x90]
  252a34: e59b012c     	ldr	r0, [r11, #0x12c]
  252a38: e58b0094     	str	r0, [r11, #0x94]
  252a3c: e59b0130     	ldr	r0, [r11, #0x130]
  252a40: e58b0098     	str	r0, [r11, #0x98]
  252a44: e1a0000c     	mov	r0, r12
  252a48: e59b1134     	ldr	r1, [r11, #0x134]
  252a4c: e59b2138     	ldr	r2, [r11, #0x138]
  252a50: e59b313c     	ldr	r3, [r11, #0x13c]
  252a54: e59ce000     	ldr	lr, [r12]
  252a58: eb00fb04     	bl	0x291670 <start+0x284ba4> @ imm = #0x3ec10 // System.Void UnityEngine.Rigidbody::set_velocity(UnityEngine.Vector3)
  252a5c: e59f0000     	ldr	r0, [pc]                @ 0x252a64 <start+0x245f98>
  252a60: ea000000     	b	0x252a68 <start+0x245f9c> @ imm = #0x0
  252a64: 004fe374     	subeq	lr, pc, r4, ror r3
  252a68: e79f0000     	ldr	r0, [pc, r0]
  252a6c: ed900a00     	vldr	s0, [r0]
  252a70: eeb72ac0     	vcvt.f64.f32	d2, s0
  252a74: eeb02b42     	vmov.f64	d2, d2
  252a78: eeb02b42     	vmov.f64	d2, d2
  252a7c: eeb70bc2     	vcvt.f32.f64	s0, d2
  252a80: ed8b0a14     	vstr	s0, [r11, #80]
  252a84: e1a0000a     	mov	r0, r10
  252a88: e59ae000     	ldr	lr, [r10]
  252a8c: eb00fdd7     	bl	0x2921f0 <start+0x285724> @ imm = #0x3f75c // UnityEngine.Rigidbody UnityEngine.Component::get_rigidbody()
  252a90: e1a02000     	mov	r2, r0
  252a94: e28b0f50     	add	r0, r11, #80, #30
  252a98: e1a01002     	mov	r1, r2
  252a9c: e592e000     	ldr	lr, [r2]
  252aa0: eb00faee     	bl	0x291660 <start+0x284b94> @ imm = #0x3ebb8 // UnityEngine.Vector3 UnityEngine.Rigidbody::get_velocity()
  252aa4: e59b0140     	ldr	r0, [r11, #0x140]
  252aa8: e58b0054     	str	r0, [r11, #0x54]
  252aac: e59b0144     	ldr	r0, [r11, #0x144]
  252ab0: e58b0058     	str	r0, [r11, #0x58]
  252ab4: e59b0148     	ldr	r0, [r11, #0x148]
  252ab8: e58b005c     	str	r0, [r11, #0x5c]
  252abc: ed9b0a14     	vldr	s0, [r11, #80]
  252ac0: eeb72ac0     	vcvt.f64.f32	d2, s0
  252ac4: eeb03b42     	vmov.f64	d3, d2
  252ac8: eeb03b43     	vmov.f64	d3, d3
  252acc: eeb02b43     	vmov.f64	d2, d3
  252ad0: eeb02b42     	vmov.f64	d2, d2
  252ad4: eeb03b43     	vmov.f64	d3, d3
  252ad8: eeb70bc3     	vcvt.f32.f64	s0, d3
  252adc: ed8b0a27     	vstr	s0, [r11, #156]
  252ae0: eeb70bc2     	vcvt.f32.f64	s0, d2
  252ae4: ed8b0a15     	vstr	s0, [r11, #84]
  252ae8: e1a0000a     	mov	r0, r10
  252aec: e59ae000     	ldr	lr, [r10]
  252af0: eb00fdbe     	bl	0x2921f0 <start+0x285724> @ imm = #0x3f6f8 // UnityEngine.Rigidbody UnityEngine.Component::get_rigidbody()
  252af4: e1a0c000     	mov	r12, r0
  252af8: e59b0054     	ldr	r0, [r11, #0x54]
  252afc: e58b014c     	str	r0, [r11, #0x14c]
  252b00: e59b0058     	ldr	r0, [r11, #0x58]
  252b04: e58b0150     	str	r0, [r11, #0x150]
  252b08: e59b005c     	ldr	r0, [r11, #0x5c]
  252b0c: e58b0154     	str	r0, [r11, #0x154]
  252b10: e59b014c     	ldr	r0, [r11, #0x14c]
  252b14: e58b0158     	str	r0, [r11, #0x158]
  252b18: e59b0150     	ldr	r0, [r11, #0x150]
  252b1c: e58b015c     	str	r0, [r11, #0x15c]
  252b20: e59b0154     	ldr	r0, [r11, #0x154]
  252b24: e58b0160     	str	r0, [r11, #0x160]
  252b28: e59b014c     	ldr	r0, [r11, #0x14c]
  252b2c: e58b00a0     	str	r0, [r11, #0xa0]
  252b30: e59b0150     	ldr	r0, [r11, #0x150]
  252b34: e58b00a4     	str	r0, [r11, #0xa4]
  252b38: e59b0154     	ldr	r0, [r11, #0x154]
  252b3c: e58b00a8     	str	r0, [r11, #0xa8]
  252b40: e1a0000c     	mov	r0, r12
  252b44: e59b1158     	ldr	r1, [r11, #0x158]
  252b48: e59b215c     	ldr	r2, [r11, #0x15c]
  252b4c: e59b3160     	ldr	r3, [r11, #0x160]
  252b50: e59ce000     	ldr	lr, [r12]
  252b54: eb00fac5     	bl	0x291670 <start+0x284ba4> @ imm = #0x3eb14 // System.Void UnityEngine.Rigidbody::set_velocity(UnityEngine.Vector3)
  252b58: e1a0000a     	mov	r0, r10
  252b5c: e59ae000     	ldr	lr, [r10]
  252b60: eb00fda2     	bl	0x2921f0 <start+0x285724> @ imm = #0x3f688 // UnityEngine.Rigidbody UnityEngine.Component::get_rigidbody()
  252b64: e58b0180     	str	r0, [r11, #0x180]
  252b68: e28b0f59     	add	r0, r11, #356
  252b6c: eb00fdef     	bl	0x292330 <start+0x285864> @ imm = #0x3f7bc // UnityEngine.Vector3 UnityEngine.Vector3::get_right()
  252b70: ed9a0ae7     	vldr	s0, [r10, #924]
  252b74: eeb72ac0     	vcvt.f64.f32	d2, s0
  252b78: e28b0f5c     	add	r0, r11, #92, #30
  252b7c: e59b1164     	ldr	r1, [r11, #0x164]
  252b80: e59b2168     	ldr	r2, [r11, #0x168]
  252b84: e59b316c     	ldr	r3, [r11, #0x16c]
  252b88: eeb70bc2     	vcvt.f32.f64	s0, d2
  252b8c: ed8d0a00     	vstr	s0, [sp]
  252b90: eb00fcd2     	bl	0x291ee0 <start+0x285414> @ imm = #0x3f348 // UnityEngine.Vector3 UnityEngine.Vector3::op_Multiply(UnityEngine.Vector3,System.Single)
  252b94: e59bc180     	ldr	r12, [r11, #0x180]
  252b98: e1a0000c     	mov	r0, r12
  252b9c: e59b1170     	ldr	r1, [r11, #0x170]
  252ba0: e59b2174     	ldr	r2, [r11, #0x174]
  252ba4: e59b3178     	ldr	r3, [r11, #0x178]
  252ba8: e59ce000     	ldr	lr, [r12]
  252bac: eb00fde3     	bl	0x292340 <start+0x285874> @ imm = #0x3f78c // System.Void UnityEngine.Rigidbody::AddTorque(UnityEngine.Vector3)
  252bb0: eb00faba     	bl	0x2916a0 <start+0x284bd4> @ imm = #0x3eae8 // System.Single UnityEngine.Time::get_time()
  252bb4: ee020a10     	vmov	s4, r0
  252bb8: eeb72ac2     	vcvt.f64.f32	d2, s4
  252bbc: ed9a0af3     	vldr	s0, [r10, #972]
  252bc0: eeb73ac0     	vcvt.f64.f32	d3, s0
  252bc4: ee322b03     	vadd.f64	d2, d2, d3
  252bc8: e59f0000     	ldr	r0, [pc]                @ 0x252bd0 <start+0x246104>
  252bcc: ea000000     	b	0x252bd4 <start+0x246108> @ imm = #0x0
  252bd0: 004fde88     	subeq	sp, pc, r8, lsl #29
  252bd4: e79f0000     	ldr	r0, [pc, r0]
  252bd8: eeb70bc2     	vcvt.f32.f64	s0, d2
  252bdc: ed800a00     	vstr	s0, [r0]
  252be0: eb00faae     	bl	0x2916a0 <start+0x284bd4> @ imm = #0x3eab8 // System.Single UnityEngine.Time::get_time()
  252be4: ee020a10     	vmov	s4, r0
  252be8: eeb72ac2     	vcvt.f64.f32	d2, s4
  252bec: eeb70bc2     	vcvt.f32.f64	s0, d2
  252bf0: ed8a0af2     	vstr	s0, [r10, #968]
  252bf4: e59f0000     	ldr	r0, [pc]                @ 0x252bfc <start+0x246130>
  252bf8: ea000000     	b	0x252c00 <start+0x246134> @ imm = #0x0
  252bfc: 004fde04     	subeq	sp, pc, r4, lsl #28
  252c00: e79f0000     	ldr	r0, [pc, r0]
  252c04: e5d00000     	ldrb	r0, [r0]
  252c08: e3500000     	cmp	r0, #0
  252c0c: 1a00000d     	bne	0x252c48 <start+0x24617c> @ imm = #0x34
  252c10: e1a0000a     	mov	r0, r10
  252c14: e59ae000     	ldr	lr, [r10]
  252c18: eb00fa34     	bl	0x2914f0 <start+0x284a24> @ imm = #0x3e8d0 // UnityEngine.AudioSource UnityEngine.Component::get_audio()
  252c1c: e1a02000     	mov	r2, r0
  252c20: e59a1040     	ldr	r1, [r10, #0x40]
  252c24: e1a00002     	mov	r0, r2
  252c28: e592e000     	ldr	lr, [r2]
  252c2c: eb00fa33     	bl	0x291500 <start+0x284a34> @ imm = #0x3e8cc // System.Void UnityEngine.AudioSource::set_clip(UnityEngine.AudioClip)
  252c30: e1a0000a     	mov	r0, r10
  252c34: e59ae000     	ldr	lr, [r10]
  252c38: eb00fa2c     	bl	0x2914f0 <start+0x284a24> @ imm = #0x3e8b0 // UnityEngine.AudioSource UnityEngine.Component::get_audio()
  252c3c: e1a01000     	mov	r1, r0
  252c40: e591e000     	ldr	lr, [r1]
  252c44: eb00fa31     	bl	0x291510 <start+0x284a44> @ imm = #0x3e8c4 // System.Void UnityEngine.AudioSource::Play()
  252c48: e59f0000     	ldr	r0, [pc]                @ 0x252c50 <start+0x246184>
  252c4c: ea000000     	b	0x252c54 <start+0x246188> @ imm = #0x0
  252c50: 004fe334     	subeq	lr, pc, r4, lsr r3
  252c54: e79f0000     	ldr	r0, [pc, r0]
  252c58: e3a01001     	mov	r1, #1
  252c5c: e5801000     	str	r1, [r0]
  252c60: e59f0000     	ldr	r0, [pc]                @ 0x252c68 <start+0x24619c>
  252c64: ea000000     	b	0x252c6c <start+0x2461a0> @ imm = #0x0
  252c68: 004fe288     	subeq	lr, pc, r8, lsl #5
  252c6c: e79f0000     	ldr	r0, [pc, r0]
  252c70: e5900000     	ldr	r0, [r0]
  252c74: e3500001     	cmp	r0, #1
  252c78: 13a00000     	movne	r0, #0
  252c7c: 03a00001     	moveq	r0, #1
  252c80: e3500000     	cmp	r0, #0
  252c84: 0a000017     	beq	0x252ce8 <start+0x24621c> @ imm = #0x5c
  252c88: e5da03c0     	ldrb	r0, [r10, #0x3c0]
  252c8c: e3500000     	cmp	r0, #0
  252c90: 1a000014     	bne	0x252ce8 <start+0x24621c> @ imm = #0x50
  252c94: e59f0000     	ldr	r0, [pc]                @ 0x252c9c <start+0x2461d0>
  252c98: ea000000     	b	0x252ca0 <start+0x2461d4> @ imm = #0x0
  252c9c: 004fe12c     	subeq	lr, pc, r12, lsr #2
  252ca0: e79f0000     	ldr	r0, [pc, r0]
  252ca4: e3a01000     	mov	r1, #0
  252ca8: e5c01000     	strb	r1, [r0]
  252cac: e59f0000     	ldr	r0, [pc]                @ 0x252cb4 <start+0x2461e8>
  252cb0: ea000000     	b	0x252cb8 <start+0x2461ec> @ imm = #0x0
  252cb4: 004fe23c     	subeq	lr, pc, r12, lsr r2
  252cb8: e79f0000     	ldr	r0, [pc, r0]
  252cbc: e3a01002     	mov	r1, #2
  252cc0: e5801000     	str	r1, [r0]
  252cc4: e59a2094     	ldr	r2, [r10, #0x94]
  252cc8: e1a00002     	mov	r0, r2
  252ccc: e3a01000     	mov	r1, #0
  252cd0: e592e000     	ldr	lr, [r2]
  252cd4: eb00fa99     	bl	0x291740 <start+0x284c74> @ imm = #0x3ea64 // System.Void UnityEngine.GameObject::SetActiveRecursively(System.Boolean)
  252cd8: e1a0000a     	mov	r0, r10
  252cdc: e3a01001     	mov	r1, #1
  252ce0: e59ae000     	ldr	lr, [r10]
  252ce4: eb00fd99     	bl	0x292350 <start+0x285884> @ imm = #0x3f664 // System.Void QuarterTrigger::SetRackupState(System.Boolean)
  252ce8: e28bdf66     	add	sp, r11, #408
  252cec: e8bd0d40     	pop	{r6, r8, r10, r11}
  252cf0: e59d7008     	ldr	r7, [sp, #0x8]
  252cf4: e89da000     	ldm	sp, {sp, pc}
  252cf8: e1a0100e     	mov	r1, lr
  252cfc: e59f0000     	ldr	r0, [pc]                @ 0x252d04 <start+0x246238>
  252d00: eb00fa0e     	bl	0x291540 <start+0x284a74> @ imm = #0x3e838
  252d04: 020000fd     	andeq	r0, r0, #253
  252d08: e1a0100e     	mov	r1, lr
  252d0c: e59f0000     	ldr	r0, [pc]                @ 0x252d14 <start+0x246248>
  252d10: eb00fa0a     	bl	0x291540 <start+0x284a74> @ imm = #0x3e828
  252d14: 020000ac     	andeq	r0, r0, #172
