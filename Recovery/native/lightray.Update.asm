
/Users/tomato/Documents/Codex/iQuarters/Recovery/native/iquarters-armv7:	file format mach-o arm

Disassembly of section __TEXT,__text:

0000cacc <start>:
  2379ac: e1a0c00d     	mov	r12, sp
  2379b0: e92d4080     	push	{r7, lr}
  2379b4: e1a0700d     	mov	r7, sp
  2379b8: e92d5d70     	push	{r4, r5, r6, r8, r10, r11, r12, lr}
  2379bc: e24ddf44     	sub	sp, sp, #68, #30
  2379c0: e1a0b00d     	mov	r11, sp
  2379c4: e1a0a000     	mov	r10, r0
  2379c8: e3a00000     	mov	r0, #0
  2379cc: e58b000c     	str	r0, [r11, #0xc]
  2379d0: e3a00000     	mov	r0, #0
  2379d4: e58b0010     	str	r0, [r11, #0x10]
  2379d8: e3a00000     	mov	r0, #0
  2379dc: e58b0014     	str	r0, [r11, #0x14]
  2379e0: e3a00000     	mov	r0, #0
  2379e4: e58b001c     	str	r0, [r11, #0x1c]
  2379e8: e3a00000     	mov	r0, #0
  2379ec: e58b0020     	str	r0, [r11, #0x20]
  2379f0: e3a00000     	mov	r0, #0
  2379f4: e58b0024     	str	r0, [r11, #0x24]
  2379f8: e3a00000     	mov	r0, #0
  2379fc: e58b002c     	str	r0, [r11, #0x2c]
  237a00: e3a00000     	mov	r0, #0
  237a04: e58b0030     	str	r0, [r11, #0x30]
  237a08: e3a00000     	mov	r0, #0
  237a0c: e58b0034     	str	r0, [r11, #0x34]
  237a10: e3a00000     	mov	r0, #0
  237a14: e58b0038     	str	r0, [r11, #0x38]
  237a18: e3a00000     	mov	r0, #0
  237a1c: e58b003c     	str	r0, [r11, #0x3c]
  237a20: e3a00000     	mov	r0, #0
  237a24: e58b0040     	str	r0, [r11, #0x40]
  237a28: e3a00000     	mov	r0, #0
  237a2c: e58b0048     	str	r0, [r11, #0x48]
  237a30: e3a00000     	mov	r0, #0
  237a34: e58b004c     	str	r0, [r11, #0x4c]
  237a38: e3a00000     	mov	r0, #0
  237a3c: e58b0050     	str	r0, [r11, #0x50]
  237a40: e3a00000     	mov	r0, #0
  237a44: e58b0054     	str	r0, [r11, #0x54]
  237a48: e3a00000     	mov	r0, #0
  237a4c: e58b0058     	str	r0, [r11, #0x58]
  237a50: e3a00000     	mov	r0, #0
  237a54: e58b005c     	str	r0, [r11, #0x5c]
  237a58: e3a00000     	mov	r0, #0
  237a5c: e58b0064     	str	r0, [r11, #0x64]
  237a60: e3a00000     	mov	r0, #0
  237a64: e58b0068     	str	r0, [r11, #0x68]
  237a68: e3a00000     	mov	r0, #0
  237a6c: e58b006c     	str	r0, [r11, #0x6c]
  237a70: e3a00000     	mov	r0, #0
  237a74: e58b0070     	str	r0, [r11, #0x70]
  237a78: e3a00000     	mov	r0, #0
  237a7c: e58b0074     	str	r0, [r11, #0x74]
  237a80: e3a00000     	mov	r0, #0
  237a84: e58b0078     	str	r0, [r11, #0x78]
  237a88: e3a00000     	mov	r0, #0
  237a8c: e58b0080     	str	r0, [r11, #0x80]
  237a90: e3a00000     	mov	r0, #0
  237a94: e58b0084     	str	r0, [r11, #0x84]
  237a98: e3a00000     	mov	r0, #0
  237a9c: e58b0088     	str	r0, [r11, #0x88]
  237aa0: e59f0000     	ldr	r0, [pc]                @ 0x237aa8 <start+0x22afdc>
  237aa4: ea000000     	b	0x237aac <start+0x22afe0> @ imm = #0x0
  237aa8: 00519040     	subseq	r9, r1, r0, asr #32
  237aac: e79f0000     	ldr	r0, [pc, r0]
  237ab0: e5d00000     	ldrb	r0, [r0]
  237ab4: e3500000     	cmp	r0, #0
  237ab8: 0a00009e     	beq	0x237d38 <start+0x22b26c> @ imm = #0x278
  237abc: e1a0000a     	mov	r0, r10
  237ac0: e59ae000     	ldr	lr, [r10]
  237ac4: eb0166a1     	bl	0x291550 <start+0x284a84> @ imm = #0x59a84 // UnityEngine.Animation UnityEngine.Component::get_animation()
  237ac8: eb0166a4     	bl	0x291560 <start+0x284a94> @ imm = #0x59a90
  237acc: e1a05000     	mov	r5, r0
  237ad0: ea000023     	b	0x237b64 <start+0x22b098> @ imm = #0x8c
  237ad4: e1a00005     	mov	r0, r5
  237ad8: e5951000     	ldr	r1, [r5]
  237adc: e59f8000     	ldr	r8, [pc]                @ 0x237ae4 <start+0x22b018>
  237ae0: ea000000     	b	0x237ae8 <start+0x22b01c> @ imm = #0x0
  237ae4: 00518f44     	subseq	r8, r1, r4, asr #30
  237ae8: e79f8008     	ldr	r8, [pc, r8]
  237aec: e28fe004     	add	lr, pc, #4
  237af0: e511f048     	ldr	pc, [r1, #-0x48]
  237af4: 00000000     	andeq	r0, r0, r0
  237af8: e1a04000     	mov	r4, r0
  237afc: e3540000     	cmp	r4, #0
  237b00: 0a000009     	beq	0x237b2c <start+0x22b060> @ imm = #0x24
  237b04: e5940000     	ldr	r0, [r4]
  237b08: e5900000     	ldr	r0, [r0]
  237b0c: e5900008     	ldr	r0, [r0, #0x8]
  237b10: e5900008     	ldr	r0, [r0, #0x8]
  237b14: e59f1000     	ldr	r1, [pc]                @ 0x237b1c <start+0x22b050>
  237b18: ea000000     	b	0x237b20 <start+0x22b054> @ imm = #0x0
  237b1c: 00518f10     	subseq	r8, r1, r0, lsl pc
  237b20: e79f1001     	ldr	r1, [pc, r1]
  237b24: e1500001     	cmp	r0, r1
  237b28: 1b000132     	blne	0x237ff8 <start+0x22b52c> @ imm = #0x4c8
  237b2c: e1a06004     	mov	r6, r4
  237b30: ed9f2a00     	vldr	s4, [pc]                @ 0x237b38 <start+0x22b06c>
  237b34: ea000000     	b	0x237b3c <start+0x22b070> @ imm = #0x0
  237b38: 40000000     	andmi	r0, r0, r0
  237b3c: eeb72ac2     	vcvt.f64.f32	d2, s4
  237b40: e1a00004     	mov	r0, r4
  237b44: eeb70bc2     	vcvt.f32.f64	s0, d2
  237b48: ed0d0a02     	vstr	s0, [sp, #-8]
  237b4c: e51d1008     	ldr	r1, [sp, #-0x8]
  237b50: e594e000     	ldr	lr, [r4]
  237b54: eb01669d     	bl	0x2915d0 <start+0x284b04> @ imm = #0x59a74 // System.Void UnityEngine.AnimationState::set_speed(System.Single)
  237b58: e1a00005     	mov	r0, r5
  237b5c: e1a01004     	mov	r1, r4
  237b60: eb016686     	bl	0x291580 <start+0x284ab4> @ imm = #0x59a18
  237b64: e1a00005     	mov	r0, r5
  237b68: e5951000     	ldr	r1, [r5]
  237b6c: e59f8000     	ldr	r8, [pc]                @ 0x237b74 <start+0x22b0a8>
  237b70: ea000000     	b	0x237b78 <start+0x22b0ac> @ imm = #0x0
  237b74: 00518ec8     	subseq	r8, r1, r8, asr #29
  237b78: e79f8008     	ldr	r8, [pc, r8]
  237b7c: e28fe004     	add	lr, pc, #4
  237b80: e511f008     	ldr	pc, [r1, #-0x8]
  237b84: 00000000     	andeq	r0, r0, r0
  237b88: e3500000     	cmp	r0, #0
  237b8c: 1affffd0     	bne	0x237ad4 <start+0x22b008> @ imm = #-0xc0
  237b90: e1a0000a     	mov	r0, r10
  237b94: e59ae000     	ldr	lr, [r10]
  237b98: eb0166dc     	bl	0x291710 <start+0x284c44> @ imm = #0x59b70 // UnityEngine.Transform UnityEngine.Component::get_transform()
  237b9c: e58b0108     	str	r0, [r11, #0x108]
  237ba0: e59a1014     	ldr	r1, [r10, #0x14]
  237ba4: e1a00001     	mov	r0, r1
  237ba8: e591e000     	ldr	lr, [r1]
  237bac: eb0166c7     	bl	0x2916d0 <start+0x284c04> @ imm = #0x59b1c // UnityEngine.Transform UnityEngine.GameObject::get_transform()
  237bb0: e1a02000     	mov	r2, r0
  237bb4: e28b008c     	add	r0, r11, #140
  237bb8: e1a01002     	mov	r1, r2
  237bbc: e592e000     	ldr	lr, [r2]
  237bc0: eb0166c6     	bl	0x2916e0 <start+0x284c14> @ imm = #0x59b18 // UnityEngine.Vector3 UnityEngine.Transform::get_position()
  237bc4: e59bc108     	ldr	r12, [r11, #0x108]
  237bc8: e1a0000c     	mov	r0, r12
  237bcc: e59b108c     	ldr	r1, [r11, #0x8c]
  237bd0: e59b2090     	ldr	r2, [r11, #0x90]
  237bd4: e59b3094     	ldr	r3, [r11, #0x94]
  237bd8: e59ce000     	ldr	lr, [r12]
  237bdc: eb0166cf     	bl	0x291720 <start+0x284c54> @ imm = #0x59b3c // System.Void UnityEngine.Transform::set_position(UnityEngine.Vector3)
  237be0: e1a0000a     	mov	r0, r10
  237be4: e59ae000     	ldr	lr, [r10]
  237be8: eb0166c8     	bl	0x291710 <start+0x284c44> @ imm = #0x59b20 // UnityEngine.Transform UnityEngine.Component::get_transform()
  237bec: e1a02000     	mov	r2, r0
  237bf0: e28b0038     	add	r0, r11, #56
  237bf4: e1a01002     	mov	r1, r2
  237bf8: e592e000     	ldr	lr, [r2]
  237bfc: eb0166b7     	bl	0x2916e0 <start+0x284c14> @ imm = #0x59adc // UnityEngine.Vector3 UnityEngine.Transform::get_position()
  237c00: ed9b0a0f     	vldr	s0, [r11, #60]
  237c04: eeb72ac0     	vcvt.f64.f32	d2, s0
  237c08: ed9f3a00     	vldr	s6, [pc]                @ 0x237c10 <start+0x22b144>
  237c0c: ea000000     	b	0x237c14 <start+0x22b148> @ imm = #0x0
  237c10: 3df5c28f     	ldcllo	p2, c12, [r5, #572]!
  237c14: eeb73ac3     	vcvt.f64.f32	d3, s6
  237c18: ee322b43     	vsub.f64	d2, d2, d3
  237c1c: eeb02b42     	vmov.f64	d2, d2
  237c20: eeb02b42     	vmov.f64	d2, d2
  237c24: eeb70bc2     	vcvt.f32.f64	s0, d2
  237c28: ed8b0a02     	vstr	s0, [r11, #8]
  237c2c: e1a0000a     	mov	r0, r10
  237c30: e59ae000     	ldr	lr, [r10]
  237c34: eb0166b5     	bl	0x291710 <start+0x284c44> @ imm = #0x59ad4 // UnityEngine.Transform UnityEngine.Component::get_transform()
  237c38: e1a02000     	mov	r2, r0
  237c3c: e28b0098     	add	r0, r11, #152
  237c40: e1a01002     	mov	r1, r2
  237c44: e592e000     	ldr	lr, [r2]
  237c48: eb0166a4     	bl	0x2916e0 <start+0x284c14> @ imm = #0x59a90 // UnityEngine.Vector3 UnityEngine.Transform::get_position()
  237c4c: e59b0098     	ldr	r0, [r11, #0x98]
  237c50: e58b000c     	str	r0, [r11, #0xc]
  237c54: e59b009c     	ldr	r0, [r11, #0x9c]
  237c58: e58b0010     	str	r0, [r11, #0x10]
  237c5c: e59b00a0     	ldr	r0, [r11, #0xa0]
  237c60: e58b0014     	str	r0, [r11, #0x14]
  237c64: ed9b0a02     	vldr	s0, [r11, #8]
  237c68: eeb72ac0     	vcvt.f64.f32	d2, s0
  237c6c: eeb03b42     	vmov.f64	d3, d2
  237c70: eeb03b43     	vmov.f64	d3, d3
  237c74: eeb02b43     	vmov.f64	d2, d3
  237c78: eeb02b42     	vmov.f64	d2, d2
  237c7c: eeb03b43     	vmov.f64	d3, d3
  237c80: eeb70bc3     	vcvt.f32.f64	s0, d3
  237c84: ed8b0a11     	vstr	s0, [r11, #68]
  237c88: eeb70bc2     	vcvt.f32.f64	s0, d2
  237c8c: ed8b0a04     	vstr	s0, [r11, #16]
  237c90: e1a0000a     	mov	r0, r10
  237c94: e59ae000     	ldr	lr, [r10]
  237c98: eb01669c     	bl	0x291710 <start+0x284c44> @ imm = #0x59a70 // UnityEngine.Transform UnityEngine.Component::get_transform()
  237c9c: e1a0c000     	mov	r12, r0
  237ca0: e59b000c     	ldr	r0, [r11, #0xc]
  237ca4: e58b00a4     	str	r0, [r11, #0xa4]
  237ca8: e59b0010     	ldr	r0, [r11, #0x10]
  237cac: e58b00a8     	str	r0, [r11, #0xa8]
  237cb0: e59b0014     	ldr	r0, [r11, #0x14]
  237cb4: e58b00ac     	str	r0, [r11, #0xac]
  237cb8: e59b00a4     	ldr	r0, [r11, #0xa4]
  237cbc: e58b00b0     	str	r0, [r11, #0xb0]
  237cc0: e59b00a8     	ldr	r0, [r11, #0xa8]
  237cc4: e58b00b4     	str	r0, [r11, #0xb4]
  237cc8: e59b00ac     	ldr	r0, [r11, #0xac]
  237ccc: e58b00b8     	str	r0, [r11, #0xb8]
  237cd0: e59b00a4     	ldr	r0, [r11, #0xa4]
  237cd4: e58b0048     	str	r0, [r11, #0x48]
  237cd8: e59b00a8     	ldr	r0, [r11, #0xa8]
  237cdc: e58b004c     	str	r0, [r11, #0x4c]
  237ce0: e59b00ac     	ldr	r0, [r11, #0xac]
  237ce4: e58b0050     	str	r0, [r11, #0x50]
  237ce8: e1a0000c     	mov	r0, r12
  237cec: e59b10b0     	ldr	r1, [r11, #0xb0]
  237cf0: e59b20b4     	ldr	r2, [r11, #0xb4]
  237cf4: e59b30b8     	ldr	r3, [r11, #0xb8]
  237cf8: e59ce000     	ldr	lr, [r12]
  237cfc: eb016687     	bl	0x291720 <start+0x284c54> @ imm = #0x59a1c // System.Void UnityEngine.Transform::set_position(UnityEngine.Vector3)
  237d00: e1a0000a     	mov	r0, r10
  237d04: e59ae000     	ldr	lr, [r10]
  237d08: eb016610     	bl	0x291550 <start+0x284a84> @ imm = #0x59840 // UnityEngine.Animation UnityEngine.Component::get_animation()
  237d0c: e1a01000     	mov	r1, r0
  237d10: e591e000     	ldr	lr, [r1]
  237d14: eb016659     	bl	0x291680 <start+0x284bb4> @ imm = #0x59964 // System.Boolean UnityEngine.Animation::Play()
  237d18: e59a0028     	ldr	r0, [r10, #0x28]
  237d1c: e58a002c     	str	r0, [r10, #0x2c]
  237d20: e59f0000     	ldr	r0, [pc]                @ 0x237d28 <start+0x22b25c>
  237d24: ea000000     	b	0x237d2c <start+0x22b260> @ imm = #0x0
  237d28: 00518dc0     	subseq	r8, r1, r0, asr #27
  237d2c: e79f0000     	ldr	r0, [pc, r0]
  237d30: e3a01000     	mov	r1, #0
  237d34: e5c01000     	strb	r1, [r0]
  237d38: e59a402c     	ldr	r4, [r10, #0x2c]
  237d3c: e1a00004     	mov	r0, r4
  237d40: e59a1028     	ldr	r1, [r10, #0x28]
  237d44: e1500001     	cmp	r0, r1
  237d48: 13a00000     	movne	r0, #0
  237d4c: 03a00001     	moveq	r0, #1
  237d50: e3500000     	cmp	r0, #0
  237d54: 0a0000a3     	beq	0x237fe8 <start+0x22b51c> @ imm = #0x28c
  237d58: e59f0000     	ldr	r0, [pc]                @ 0x237d60 <start+0x22b294>
  237d5c: ea000000     	b	0x237d64 <start+0x22b298> @ imm = #0x0
  237d60: 00518d90     	<unknown>
  237d64: e79f0000     	ldr	r0, [pc, r0]
  237d68: e5900000     	ldr	r0, [r0]
  237d6c: e350000b     	cmp	r0, #11
  237d70: 13a00000     	movne	r0, #0
  237d74: 03a00001     	moveq	r0, #1
  237d78: e3500000     	cmp	r0, #0
  237d7c: 0a000087     	beq	0x237fa0 <start+0x22b4d4> @ imm = #0x21c
  237d80: e59a1018     	ldr	r1, [r10, #0x18]
  237d84: e1a00001     	mov	r0, r1
  237d88: e591e000     	ldr	lr, [r1]
  237d8c: eb01664f     	bl	0x2916d0 <start+0x284c04> @ imm = #0x5993c // UnityEngine.Transform UnityEngine.GameObject::get_transform()
  237d90: e1a02000     	mov	r2, r0
  237d94: e28b0054     	add	r0, r11, #84
  237d98: e1a01002     	mov	r1, r2
  237d9c: e592e000     	ldr	lr, [r2]
  237da0: eb01664e     	bl	0x2916e0 <start+0x284c14> @ imm = #0x59938 // UnityEngine.Vector3 UnityEngine.Transform::get_position()
  237da4: ed9b0a15     	vldr	s0, [r11, #84]
  237da8: eeb72ac0     	vcvt.f64.f32	d2, s0
  237dac: eeb02b42     	vmov.f64	d2, d2
  237db0: eeb02b42     	vmov.f64	d2, d2
  237db4: eeb70bc2     	vcvt.f32.f64	s0, d2
  237db8: ed8b0a06     	vstr	s0, [r11, #24]
  237dbc: e1a0000a     	mov	r0, r10
  237dc0: e59ae000     	ldr	lr, [r10]
  237dc4: eb016651     	bl	0x291710 <start+0x284c44> @ imm = #0x59944 // UnityEngine.Transform UnityEngine.Component::get_transform()
  237dc8: e1a02000     	mov	r2, r0
  237dcc: e28b00bc     	add	r0, r11, #188
  237dd0: e1a01002     	mov	r1, r2
  237dd4: e592e000     	ldr	lr, [r2]
  237dd8: eb016640     	bl	0x2916e0 <start+0x284c14> @ imm = #0x59900 // UnityEngine.Vector3 UnityEngine.Transform::get_position()
  237ddc: e59b00bc     	ldr	r0, [r11, #0xbc]
  237de0: e58b001c     	str	r0, [r11, #0x1c]
  237de4: e59b00c0     	ldr	r0, [r11, #0xc0]
  237de8: e58b0020     	str	r0, [r11, #0x20]
  237dec: e59b00c4     	ldr	r0, [r11, #0xc4]
  237df0: e58b0024     	str	r0, [r11, #0x24]
  237df4: ed9b0a06     	vldr	s0, [r11, #24]
  237df8: eeb72ac0     	vcvt.f64.f32	d2, s0
  237dfc: eeb03b42     	vmov.f64	d3, d2
  237e00: eeb03b43     	vmov.f64	d3, d3
  237e04: eeb02b43     	vmov.f64	d2, d3
  237e08: eeb02b42     	vmov.f64	d2, d2
  237e0c: eeb03b43     	vmov.f64	d3, d3
  237e10: eeb70bc3     	vcvt.f32.f64	s0, d3
  237e14: ed8b0a18     	vstr	s0, [r11, #96]
  237e18: eeb70bc2     	vcvt.f32.f64	s0, d2
  237e1c: ed8b0a07     	vstr	s0, [r11, #28]
  237e20: e1a0000a     	mov	r0, r10
  237e24: e59ae000     	ldr	lr, [r10]
  237e28: eb016638     	bl	0x291710 <start+0x284c44> @ imm = #0x598e0 // UnityEngine.Transform UnityEngine.Component::get_transform()
  237e2c: e1a0c000     	mov	r12, r0
  237e30: e59b001c     	ldr	r0, [r11, #0x1c]
  237e34: e58b00c8     	str	r0, [r11, #0xc8]
  237e38: e59b0020     	ldr	r0, [r11, #0x20]
  237e3c: e58b00cc     	str	r0, [r11, #0xcc]
  237e40: e59b0024     	ldr	r0, [r11, #0x24]
  237e44: e58b00d0     	str	r0, [r11, #0xd0]
  237e48: e59b00c8     	ldr	r0, [r11, #0xc8]
  237e4c: e58b00d4     	str	r0, [r11, #0xd4]
  237e50: e59b00cc     	ldr	r0, [r11, #0xcc]
  237e54: e58b00d8     	str	r0, [r11, #0xd8]
  237e58: e59b00d0     	ldr	r0, [r11, #0xd0]
  237e5c: e58b00dc     	str	r0, [r11, #0xdc]
  237e60: e59b00c8     	ldr	r0, [r11, #0xc8]
  237e64: e58b0064     	str	r0, [r11, #0x64]
  237e68: e59b00cc     	ldr	r0, [r11, #0xcc]
  237e6c: e58b0068     	str	r0, [r11, #0x68]
  237e70: e59b00d0     	ldr	r0, [r11, #0xd0]
  237e74: e58b006c     	str	r0, [r11, #0x6c]
  237e78: e1a0000c     	mov	r0, r12
  237e7c: e59b10d4     	ldr	r1, [r11, #0xd4]
  237e80: e59b20d8     	ldr	r2, [r11, #0xd8]
  237e84: e59b30dc     	ldr	r3, [r11, #0xdc]
  237e88: e59ce000     	ldr	lr, [r12]
  237e8c: eb016623     	bl	0x291720 <start+0x284c54> @ imm = #0x5988c // System.Void UnityEngine.Transform::set_position(UnityEngine.Vector3)
  237e90: e59a1018     	ldr	r1, [r10, #0x18]
  237e94: e1a00001     	mov	r0, r1
  237e98: e591e000     	ldr	lr, [r1]
  237e9c: eb01660b     	bl	0x2916d0 <start+0x284c04> @ imm = #0x5982c // UnityEngine.Transform UnityEngine.GameObject::get_transform()
  237ea0: e1a02000     	mov	r2, r0
  237ea4: e28b0070     	add	r0, r11, #112
  237ea8: e1a01002     	mov	r1, r2
  237eac: e592e000     	ldr	lr, [r2]
  237eb0: eb01660a     	bl	0x2916e0 <start+0x284c14> @ imm = #0x59828 // UnityEngine.Vector3 UnityEngine.Transform::get_position()
  237eb4: ed9b0a1e     	vldr	s0, [r11, #120]
  237eb8: eeb72ac0     	vcvt.f64.f32	d2, s0
  237ebc: eeb02b42     	vmov.f64	d2, d2
  237ec0: eeb02b42     	vmov.f64	d2, d2
  237ec4: eeb70bc2     	vcvt.f32.f64	s0, d2
  237ec8: ed8b0a0a     	vstr	s0, [r11, #40]
  237ecc: e1a0000a     	mov	r0, r10
  237ed0: e59ae000     	ldr	lr, [r10]
  237ed4: eb01660d     	bl	0x291710 <start+0x284c44> @ imm = #0x59834 // UnityEngine.Transform UnityEngine.Component::get_transform()
  237ed8: e1a02000     	mov	r2, r0
  237edc: e28b00e0     	add	r0, r11, #224
  237ee0: e1a01002     	mov	r1, r2
  237ee4: e592e000     	ldr	lr, [r2]
  237ee8: eb0165fc     	bl	0x2916e0 <start+0x284c14> @ imm = #0x597f0 // UnityEngine.Vector3 UnityEngine.Transform::get_position()
  237eec: e59b00e0     	ldr	r0, [r11, #0xe0]
  237ef0: e58b002c     	str	r0, [r11, #0x2c]
  237ef4: e59b00e4     	ldr	r0, [r11, #0xe4]
  237ef8: e58b0030     	str	r0, [r11, #0x30]
  237efc: e59b00e8     	ldr	r0, [r11, #0xe8]
  237f00: e58b0034     	str	r0, [r11, #0x34]
  237f04: ed9b0a0a     	vldr	s0, [r11, #40]
  237f08: eeb72ac0     	vcvt.f64.f32	d2, s0
  237f0c: eeb03b42     	vmov.f64	d3, d2
  237f10: eeb03b43     	vmov.f64	d3, d3
  237f14: eeb02b43     	vmov.f64	d2, d3
  237f18: eeb02b42     	vmov.f64	d2, d2
  237f1c: eeb03b43     	vmov.f64	d3, d3
  237f20: eeb70bc3     	vcvt.f32.f64	s0, d3
  237f24: ed8b0a1f     	vstr	s0, [r11, #124]
  237f28: eeb70bc2     	vcvt.f32.f64	s0, d2
  237f2c: ed8b0a0d     	vstr	s0, [r11, #52]
  237f30: e1a0000a     	mov	r0, r10
  237f34: e59ae000     	ldr	lr, [r10]
  237f38: eb0165f4     	bl	0x291710 <start+0x284c44> @ imm = #0x597d0 // UnityEngine.Transform UnityEngine.Component::get_transform()
  237f3c: e1a0c000     	mov	r12, r0
  237f40: e59b002c     	ldr	r0, [r11, #0x2c]
  237f44: e58b00ec     	str	r0, [r11, #0xec]
  237f48: e59b0030     	ldr	r0, [r11, #0x30]
  237f4c: e58b00f0     	str	r0, [r11, #0xf0]
  237f50: e59b0034     	ldr	r0, [r11, #0x34]
  237f54: e58b00f4     	str	r0, [r11, #0xf4]
  237f58: e59b00ec     	ldr	r0, [r11, #0xec]
  237f5c: e58b00f8     	str	r0, [r11, #0xf8]
  237f60: e59b00f0     	ldr	r0, [r11, #0xf0]
  237f64: e58b00fc     	str	r0, [r11, #0xfc]
  237f68: e59b00f4     	ldr	r0, [r11, #0xf4]
  237f6c: e58b0100     	str	r0, [r11, #0x100]
  237f70: e59b00ec     	ldr	r0, [r11, #0xec]
  237f74: e58b0080     	str	r0, [r11, #0x80]
  237f78: e59b00f0     	ldr	r0, [r11, #0xf0]
  237f7c: e58b0084     	str	r0, [r11, #0x84]
  237f80: e59b00f4     	ldr	r0, [r11, #0xf4]
  237f84: e58b0088     	str	r0, [r11, #0x88]
  237f88: e1a0000c     	mov	r0, r12
  237f8c: e59b10f8     	ldr	r1, [r11, #0xf8]
  237f90: e59b20fc     	ldr	r2, [r11, #0xfc]
  237f94: e59b3100     	ldr	r3, [r11, #0x100]
  237f98: e59ce000     	ldr	lr, [r12]
  237f9c: eb0165df     	bl	0x291720 <start+0x284c54> @ imm = #0x5977c // System.Void UnityEngine.Transform::set_position(UnityEngine.Vector3)
  237fa0: e1a0000a     	mov	r0, r10
  237fa4: e59ae000     	ldr	lr, [r10]
  237fa8: eb016568     	bl	0x291550 <start+0x284a84> @ imm = #0x595a0 // UnityEngine.Animation UnityEngine.Component::get_animation()
  237fac: e1a01000     	mov	r1, r0
  237fb0: e591e000     	ldr	lr, [r1]
  237fb4: eb016649     	bl	0x2918e0 <start+0x284e14> @ imm = #0x59924 // System.Boolean UnityEngine.Animation::get_isPlaying()
  237fb8: e3500000     	cmp	r0, #0
  237fbc: 1a000009     	bne	0x237fe8 <start+0x22b51c> @ imm = #0x24
  237fc0: e1a0000a     	mov	r0, r10
  237fc4: e59ae000     	ldr	lr, [r10]
  237fc8: ebfffe25     	bl	0x237864 <start+0x22ad98> @ imm = #-0x76c
  237fcc: e59a2010     	ldr	r2, [r10, #0x10]
  237fd0: e1a00002     	mov	r0, r2
  237fd4: e3a01000     	mov	r1, #0
  237fd8: e592e000     	ldr	lr, [r2]
  237fdc: eb0165d7     	bl	0x291740 <start+0x284c74> @ imm = #0x5975c // System.Void UnityEngine.GameObject::SetActiveRecursively(System.Boolean)
  237fe0: e59a0024     	ldr	r0, [r10, #0x24]
  237fe4: e58a002c     	str	r0, [r10, #0x2c]
  237fe8: e28bdf44     	add	sp, r11, #68, #30
  237fec: e8bd0d70     	pop	{r4, r5, r6, r8, r10, r11}
  237ff0: e59d7008     	ldr	r7, [sp, #0x8]
  237ff4: e89da000     	ldm	sp, {sp, pc}
  237ff8: e1a0100e     	mov	r1, lr
  237ffc: e59f0000     	ldr	r0, [pc]                @ 0x238004 <start+0x22b538>
  238000: eb01654e     	bl	0x291540 <start+0x284a74> @ imm = #0x59538
  238004: 020000ac     	andeq	r0, r0, #172
