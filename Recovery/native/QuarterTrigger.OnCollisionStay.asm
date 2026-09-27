
/Users/tomato/Documents/Codex/iQuarters/Recovery/native/iquarters-armv7:	file format mach-o arm

Disassembly of section __TEXT,__text:

0000cacc <start>:
  252194: e1a0c00d     	mov	r12, sp
  252198: e92d4080     	push	{r7, lr}
  25219c: e1a0700d     	mov	r7, sp
  2521a0: e92d5d70     	push	{r4, r5, r6, r8, r10, r11, r12, lr}
  2521a4: e24dd010     	sub	sp, sp, #16
  2521a8: e1a0b00d     	mov	r11, sp
  2521ac: e1a06000     	mov	r6, r0
  2521b0: e1a0a001     	mov	r10, r1
  2521b4: e3a00000     	mov	r0, #0
  2521b8: e58b0000     	str	r0, [r11]
  2521bc: e3a00000     	mov	r0, #0
  2521c0: e58b0004     	str	r0, [r11, #0x4]
  2521c4: e3a00000     	mov	r0, #0
  2521c8: e58b0008     	str	r0, [r11, #0x8]
  2521cc: e3a05000     	mov	r5, #0
  2521d0: e59ae000     	ldr	lr, [r10]
  2521d4: e59aa01c     	ldr	r10, [r10, #0x1c]
  2521d8: e1a0000a     	mov	r0, r10
  2521dc: e590400c     	ldr	r4, [r0, #0xc]
  2521e0: ea000024     	b	0x252278 <start+0x2457ac> @ imm = #0x90
  2521e4: e59a000c     	ldr	r0, [r10, #0xc]
  2521e8: e1500005     	cmp	r0, r5
  2521ec: 9b00002b     	blls	0x2522a0 <start+0x2457d4> @ imm = #0xac
  2521f0: e1a00285     	lsl	r0, r5, #5
  2521f4: e08a0000     	add	r0, r10, r0
  2521f8: e2800010     	add	r0, r0, #16
  2521fc: e280000c     	add	r0, r0, #12
  252200: e5901000     	ldr	r1, [r0]
  252204: e58b1000     	str	r1, [r11]
  252208: e5901004     	ldr	r1, [r0, #0x4]
  25220c: e58b1004     	str	r1, [r11, #0x4]
  252210: e5900008     	ldr	r0, [r0, #0x8]
  252214: e58b0008     	str	r0, [r11, #0x8]
  252218: ed9b0a01     	vldr	s0, [r11, #4]
  25221c: eeb72ac0     	vcvt.f64.f32	d2, s0
  252220: ed9f3a00     	vldr	s6, [pc]                @ 0x252228 <start+0x24575c>
  252224: ea000000     	b	0x25222c <start+0x245760> @ imm = #0x0
  252228: 3d4ccccd     	stcllo	p12, c12, [r12, #-820]
  25222c: eeb73ac3     	vcvt.f64.f32	d3, s6
  252230: eeb43b42     	vcmp.f64	d3, d2
  252234: eef1fa10     	vmrs	APSR_nzcv, fpscr
  252238: e3a00000     	mov	r0, #0
  25223c: 43a00001     	movmi	r0, #1
  252240: e3500000     	cmp	r0, #0
  252244: 0a000007     	beq	0x252268 <start+0x24579c> @ imm = #0x1c
  252248: e59a000c     	ldr	r0, [r10, #0xc]
  25224c: e1500005     	cmp	r0, r5
  252250: 9b000012     	blls	0x2522a0 <start+0x2457d4> @ imm = #0x48
  252254: e1a00285     	lsl	r0, r5, #5
  252258: e08a0000     	add	r0, r10, r0
  25225c: e2800010     	add	r0, r0, #16
  252260: e590001c     	ldr	r0, [r0, #0x1c]
  252264: e58600cc     	str	r0, [r6, #0xcc]
  252268: e3a00001     	mov	r0, #1
  25226c: e0950000     	adds	r0, r5, r0
  252270: 6b000006     	blvs	0x252290 <start+0x2457c4> @ imm = #0x18
  252274: e1a05000     	mov	r5, r0
  252278: e1550004     	cmp	r5, r4
  25227c: baffffd8     	blt	0x2521e4 <start+0x245718> @ imm = #-0xa0
  252280: e28bd010     	add	sp, r11, #16
  252284: e8bd0d70     	pop	{r4, r5, r6, r8, r10, r11}
  252288: e59d7008     	ldr	r7, [sp, #0x8]
  25228c: e89da000     	ldm	sp, {sp, pc}
  252290: e1a0100e     	mov	r1, lr
  252294: e59f0000     	ldr	r0, [pc]                @ 0x25229c <start+0x2457d0>
  252298: eb00fca8     	bl	0x291540 <start+0x284a74> @ imm = #0x3f2a0
  25229c: 020000fd     	andeq	r0, r0, #253
  2522a0: e1a0100e     	mov	r1, lr
  2522a4: e59f0000     	ldr	r0, [pc]                @ 0x2522ac <start+0x2457e0>
  2522a8: eb00fca4     	bl	0x291540 <start+0x284a74> @ imm = #0x3f290
  2522ac: 020000a7     	andeq	r0, r0, #167
