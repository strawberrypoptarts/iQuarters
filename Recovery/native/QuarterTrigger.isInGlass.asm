
/Users/tomato/Documents/Codex/iQuarters/Recovery/native/iquarters-armv7:	file format mach-o arm

Disassembly of section __TEXT,__text:

0000cacc <start>:
  252d80: e1a0c00d     	mov	r12, sp
  252d84: e92d4080     	push	{r7, lr}
  252d88: e1a0700d     	mov	r7, sp
  252d8c: e92d5d70     	push	{r4, r5, r6, r8, r10, r11, r12, lr}
  252d90: e1a0b00d     	mov	r11, sp
  252d94: e1a0a000     	mov	r10, r0
  252d98: e59f0000     	ldr	r0, [pc]                @ 0x252da0 <start+0x2462d4>
  252d9c: ea000000     	b	0x252da4 <start+0x2462d8> @ imm = #0x0
  252da0: 004fe228     	subeq	lr, pc, r8, lsr #4
  252da4: e79f0000     	ldr	r0, [pc, r0]
  252da8: e3a01000     	mov	r1, #0
  252dac: e5801000     	str	r1, [r0]
  252db0: e59a00cc     	ldr	r0, [r10, #0xcc]
  252db4: eb00fa35     	bl	0x291690 <start+0x284bc4> @ imm = #0x3e8d4 // System.Boolean UnityEngine.Object::op_Implicit(UnityEngine.Object)
  252db8: e3500000     	cmp	r0, #0
  252dbc: 1a000001     	bne	0x252dc8 <start+0x2462fc> @ imm = #0x4
  252dc0: e3a04000     	mov	r4, #0
  252dc4: ea00003e     	b	0x252ec4 <start+0x2463f8> @ imm = #0xf8
  252dc8: e3a06000     	mov	r6, #0
  252dcc: e59a10cc     	ldr	r1, [r10, #0xcc]
  252dd0: e1a00001     	mov	r0, r1
  252dd4: e591e000     	ldr	lr, [r1]
  252dd8: eb00fd60     	bl	0x292360 <start+0x285894> @ imm = #0x3f580 // System.String UnityEngine.Object::get_name()
  252ddc: e1a05000     	mov	r5, r0
  252de0: e59f1000     	ldr	r1, [pc]                @ 0x252de8 <start+0x24631c>
  252de4: ea000000     	b	0x252dec <start+0x246320> @ imm = #0x0
  252de8: 004fe1f0     	strdeq	lr, pc, [pc], #-16
  252dec: e79f1001     	ldr	r1, [pc, r1]
  252df0: eb00fd5e     	bl	0x292370 <start+0x2858a4> @ imm = #0x3f578
  252df4: e3500000     	cmp	r0, #0
  252df8: 0a000001     	beq	0x252e04 <start+0x246338> @ imm = #0x4
  252dfc: e3a06001     	mov	r6, #1
  252e00: ea00001c     	b	0x252e78 <start+0x2463ac> @ imm = #0x70
  252e04: e59f1000     	ldr	r1, [pc]                @ 0x252e0c <start+0x246340>
  252e08: ea000000     	b	0x252e10 <start+0x246344> @ imm = #0x0
  252e0c: 004fe1d0     	ldrdeq	lr, pc, [pc], #-16
  252e10: e79f1001     	ldr	r1, [pc, r1]
  252e14: e1a00005     	mov	r0, r5
  252e18: eb00fd54     	bl	0x292370 <start+0x2858a4> @ imm = #0x3f550
  252e1c: e3500000     	cmp	r0, #0
  252e20: 0a000001     	beq	0x252e2c <start+0x246360> @ imm = #0x4
  252e24: e3a06002     	mov	r6, #2
  252e28: ea000012     	b	0x252e78 <start+0x2463ac> @ imm = #0x48
  252e2c: e59f1000     	ldr	r1, [pc]                @ 0x252e34 <start+0x246368>
  252e30: ea000000     	b	0x252e38 <start+0x24636c> @ imm = #0x0
  252e34: 004fe1ac     	subeq	lr, pc, r12, lsr #3
  252e38: e79f1001     	ldr	r1, [pc, r1]
  252e3c: e1a00005     	mov	r0, r5
  252e40: eb00fd4a     	bl	0x292370 <start+0x2858a4> @ imm = #0x3f528
  252e44: e3500000     	cmp	r0, #0
  252e48: 0a000001     	beq	0x252e54 <start+0x246388> @ imm = #0x4
  252e4c: e3a06003     	mov	r6, #3
  252e50: ea000008     	b	0x252e78 <start+0x2463ac> @ imm = #0x20
  252e54: e59f1000     	ldr	r1, [pc]                @ 0x252e5c <start+0x246390>
  252e58: ea000000     	b	0x252e60 <start+0x246394> @ imm = #0x0
  252e5c: 004fe188     	subeq	lr, pc, r8, lsl #3
  252e60: e79f1001     	ldr	r1, [pc, r1]
  252e64: e1a00005     	mov	r0, r5
  252e68: eb00fd40     	bl	0x292370 <start+0x2858a4> @ imm = #0x3f500
  252e6c: e3500000     	cmp	r0, #0
  252e70: 0a000000     	beq	0x252e78 <start+0x2463ac> @ imm = #0x0
  252e74: e3a06004     	mov	r6, #4
  252e78: e3560000     	cmp	r6, #0
  252e7c: e3a00000     	mov	r0, #0
  252e80: c3a00001     	movgt	r0, #1
  252e84: e3500000     	cmp	r0, #0
  252e88: 0a00000c     	beq	0x252ec0 <start+0x2463f4> @ imm = #0x30
  252e8c: e59a10cc     	ldr	r1, [r10, #0xcc]
  252e90: e1a00001     	mov	r0, r1
  252e94: e591e000     	ldr	lr, [r1]
  252e98: eb00f9ec     	bl	0x291650 <start+0x284b84> @ imm = #0x3e7b0 // UnityEngine.Rigidbody UnityEngine.Collider::get_attachedRigidbody()
  252e9c: e1a01000     	mov	r1, r0
  252ea0: e591e000     	ldr	lr, [r1]
  252ea4: eb00f99d     	bl	0x291520 <start+0x284a54> @ imm = #0x3e674 // UnityEngine.GameObject UnityEngine.Component::get_gameObject()
  252ea8: e1a01000     	mov	r1, r0
  252eac: e59f0000     	ldr	r0, [pc]                @ 0x252eb4 <start+0x2463e8>
  252eb0: ea000000     	b	0x252eb8 <start+0x2463ec> @ imm = #0x0
  252eb4: 004fe114     	subeq	lr, pc, r4, lsl r1
  252eb8: e79f0000     	ldr	r0, [pc, r0]
  252ebc: e5801000     	str	r1, [r0]
  252ec0: e1a04006     	mov	r4, r6
  252ec4: e1a00004     	mov	r0, r4
  252ec8: e28bd000     	add	sp, r11, #0
  252ecc: e8bd0d70     	pop	{r4, r5, r6, r8, r10, r11}
  252ed0: e59d7008     	ldr	r7, [sp, #0x8]
  252ed4: e89da000     	ldm	sp, {sp, pc}
