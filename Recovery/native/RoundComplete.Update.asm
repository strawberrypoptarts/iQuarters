
/Users/tomato/Documents/Codex/iQuarters/Recovery/native/iquarters-armv7:	file format mach-o arm

Disassembly of section __TEXT,__text:

0000cacc <start>:
  238d34: e1a0c00d     	mov	r12, sp
  238d38: e92d4080     	push	{r7, lr}
  238d3c: e1a0700d     	mov	r7, sp
  238d40: e92d5d20     	push	{r5, r8, r10, r11, r12, lr}
  238d44: e24dd008     	sub	sp, sp, #8
  238d48: e1a0b00d     	mov	r11, sp
  238d4c: e1a0a000     	mov	r10, r0
  238d50: e59f0000     	ldr	r0, [pc]                @ 0x238d58 <start+0x22c28c>
  238d54: ea000000     	b	0x238d5c <start+0x22c290> @ imm = #0x0
  238d58: 00517db4     	ldrheq	r7, [r1], #-212
  238d5c: e79f0000     	ldr	r0, [pc, r0]
  238d60: e5d00000     	ldrb	r0, [r0]
  238d64: e3500000     	cmp	r0, #0
  238d68: 0a000011     	beq	0x238db4 <start+0x22c2e8> @ imm = #0x44
  238d6c: e59f0000     	ldr	r0, [pc]                @ 0x238d74 <start+0x22c2a8>
  238d70: ea000000     	b	0x238d78 <start+0x22c2ac> @ imm = #0x0
  238d74: 00517da0     	subseq	r7, r1, r0, lsr #27
  238d78: e79f0000     	ldr	r0, [pc, r0]
  238d7c: e5901000     	ldr	r1, [r0]
  238d80: e58b1000     	str	r1, [r11]
  238d84: e1a0000a     	mov	r0, r10
  238d88: e59ae000     	ldr	lr, [r10]
  238d8c: eb0162f7     	bl	0x291970 <start+0x284ea4> @ imm = #0x58bdc // System.Void RoundComplete::playAnimation(System.Int32)
  238d90: e59a0020     	ldr	r0, [r10, #0x20]
  238d94: e58a002c     	str	r0, [r10, #0x2c]
  238d98: e59f0000     	ldr	r0, [pc]                @ 0x238da0 <start+0x22c2d4>
  238d9c: ea000000     	b	0x238da4 <start+0x22c2d8> @ imm = #0x0
  238da0: 00517d6c     	subseq	r7, r1, r12, ror #26
  238da4: e79f0000     	ldr	r0, [pc, r0]
  238da8: e3a01000     	mov	r1, #0
  238dac: e5c01000     	strb	r1, [r0]
  238db0: ea000045     	b	0x238ecc <start+0x22c400> @ imm = #0x114
  238db4: e59f0000     	ldr	r0, [pc]                @ 0x238dbc <start+0x22c2f0>
  238db8: ea000000     	b	0x238dc0 <start+0x22c2f4> @ imm = #0x0
  238dbc: 00517d54     	subseq	r7, r1, r4, asr sp
  238dc0: e79f0000     	ldr	r0, [pc, r0]
  238dc4: e5d00000     	ldrb	r0, [r0]
  238dc8: e3500000     	cmp	r0, #0
  238dcc: 0a00001b     	beq	0x238e40 <start+0x22c374> @ imm = #0x6c
  238dd0: e1a0000a     	mov	r0, r10
  238dd4: e59ae000     	ldr	lr, [r10]
  238dd8: eb0161dc     	bl	0x291550 <start+0x284a84> @ imm = #0x58770 // UnityEngine.Animation UnityEngine.Component::get_animation()
  238ddc: e1a02000     	mov	r2, r0
  238de0: e59f1000     	ldr	r1, [pc]                @ 0x238de8 <start+0x22c31c>
  238de4: ea000000     	b	0x238dec <start+0x22c320> @ imm = #0x0
  238de8: 00517d74     	subseq	r7, r1, r4, ror sp
  238dec: e79f1001     	ldr	r1, [pc, r1]
  238df0: e1a00002     	mov	r0, r2
  238df4: e592e000     	ldr	lr, [r2]
  238df8: eb0162bc     	bl	0x2918f0 <start+0x284e24> @ imm = #0x58af0 // System.Boolean UnityEngine.Animation::Play(System.String)
  238dfc: e59a0020     	ldr	r0, [r10, #0x20]
  238e00: e58a002c     	str	r0, [r10, #0x2c]
  238e04: e59f0000     	ldr	r0, [pc]                @ 0x238e0c <start+0x22c340>
  238e08: ea000000     	b	0x238e10 <start+0x22c344> @ imm = #0x0
  238e0c: 00517d04     	subseq	r7, r1, r4, lsl #26
  238e10: e79f0000     	ldr	r0, [pc, r0]
  238e14: e3a01000     	mov	r1, #0
  238e18: e5c01000     	strb	r1, [r0]
  238e1c: e59f0000     	ldr	r0, [pc]                @ 0x238e24 <start+0x22c358>
  238e20: ea000000     	b	0x238e28 <start+0x22c35c> @ imm = #0x0
  238e24: 00517ce4     	subseq	r7, r1, r4, ror #25
  238e28: e79f0000     	ldr	r0, [pc, r0]
  238e2c: e5901000     	ldr	r1, [r0]
  238e30: e1a0000a     	mov	r0, r10
  238e34: e59ae000     	ldr	lr, [r10]
  238e38: eb0162d0     	bl	0x291980 <start+0x284eb4> @ imm = #0x58b40 // System.Void RoundComplete::HandleTextures(System.Int32)
  238e3c: ea000022     	b	0x238ecc <start+0x22c400> @ imm = #0x88
  238e40: e59a502c     	ldr	r5, [r10, #0x2c]
  238e44: e1a00005     	mov	r0, r5
  238e48: e59a1020     	ldr	r1, [r10, #0x20]
  238e4c: e1500001     	cmp	r0, r1
  238e50: 13a00000     	movne	r0, #0
  238e54: 03a00001     	moveq	r0, #1
  238e58: e3500000     	cmp	r0, #0
  238e5c: 0a00000d     	beq	0x238e98 <start+0x22c3cc> @ imm = #0x34
  238e60: e1a0000a     	mov	r0, r10
  238e64: e59ae000     	ldr	lr, [r10]
  238e68: eb0161b8     	bl	0x291550 <start+0x284a84> @ imm = #0x586e0 // UnityEngine.Animation UnityEngine.Component::get_animation()
  238e6c: e1a01000     	mov	r1, r0
  238e70: e591e000     	ldr	lr, [r1]
  238e74: eb016299     	bl	0x2918e0 <start+0x284e14> @ imm = #0x58a64 // System.Boolean UnityEngine.Animation::get_isPlaying()
  238e78: e3500000     	cmp	r0, #0
  238e7c: 1a000012     	bne	0x238ecc <start+0x22c400> @ imm = #0x48
  238e80: e59a0028     	ldr	r0, [r10, #0x28]
  238e84: e58a002c     	str	r0, [r10, #0x2c]
  238e88: e1a0000a     	mov	r0, r10
  238e8c: e59ae000     	ldr	lr, [r10]
  238e90: ebffff7a     	bl	0x238c80 <start+0x22c1b4> @ imm = #-0x218
  238e94: ea00000c     	b	0x238ecc <start+0x22c400> @ imm = #0x30
  238e98: e59a0028     	ldr	r0, [r10, #0x28]
  238e9c: e1550000     	cmp	r5, r0
  238ea0: 13a00000     	movne	r0, #0
  238ea4: 03a00001     	moveq	r0, #1
  238ea8: e3500000     	cmp	r0, #0
  238eac: 0a000006     	beq	0x238ecc <start+0x22c400> @ imm = #0x18
  238eb0: e59a0024     	ldr	r0, [r10, #0x24]
  238eb4: e58a002c     	str	r0, [r10, #0x2c]
  238eb8: e59a2010     	ldr	r2, [r10, #0x10]
  238ebc: e1a00002     	mov	r0, r2
  238ec0: e3a01000     	mov	r1, #0
  238ec4: e592e000     	ldr	lr, [r2]
  238ec8: eb01621c     	bl	0x291740 <start+0x284c74> @ imm = #0x58870 // System.Void UnityEngine.GameObject::SetActiveRecursively(System.Boolean)
  238ecc: e28bd008     	add	sp, r11, #8
  238ed0: e8bd0d20     	pop	{r5, r8, r10, r11}
  238ed4: e59d7008     	ldr	r7, [sp, #0x8]
  238ed8: e89da000     	ldm	sp, {sp, pc}
