
/Users/tomato/Documents/Codex/iQuarters/Recovery/native/iquarters-armv7:	file format mach-o arm

Disassembly of section __TEXT,__text:

0000cacc <start>:
  27145c: e1a0c00d     	mov	r12, sp
  271460: e92d4080     	push	{r7, lr}
  271464: e1a0700d     	mov	r7, sp
  271468: e92d5d40     	push	{r6, r8, r10, r11, r12, lr}
  27146c: e1a0b00d     	mov	r11, sp
  271470: e1a0a000     	mov	r10, r0
  271474: e59f0000     	ldr	r0, [pc]                @ 0x27147c <start+0x2649b0>
  271478: ea000000     	b	0x271480 <start+0x2649b4> @ imm = #0x0
  27147c: 004dfdc4     	subeq	pc, sp, r4, asr #27
  271480: e79f0000     	ldr	r0, [pc, r0]
  271484: e5d00000     	ldrb	r0, [r0]
  271488: e3500001     	cmp	r0, #1
  27148c: 13a00000     	movne	r0, #0
  271490: 03a00001     	moveq	r0, #1
  271494: e3500000     	cmp	r0, #0
  271498: 0a00001a     	beq	0x271508 <start+0x264a3c> @ imm = #0x68
  27149c: e1a0000a     	mov	r0, r10
  2714a0: e59ae000     	ldr	lr, [r10]
  2714a4: eb008029     	bl	0x291550 <start+0x284a84> @ imm = #0x200a4 // UnityEngine.Animation UnityEngine.Component::get_animation()
  2714a8: e1a02000     	mov	r2, r0
  2714ac: e59f1000     	ldr	r1, [pc]                @ 0x2714b4 <start+0x2649e8>
  2714b0: ea000000     	b	0x2714b8 <start+0x2649ec> @ imm = #0x0
  2714b4: 004dfe5c     	subeq	pc, sp, r12, asr lr
  2714b8: e79f1001     	ldr	r1, [pc, r1]
  2714bc: e1a00002     	mov	r0, r2
  2714c0: e592e000     	ldr	lr, [r2]
  2714c4: eb008109     	bl	0x2918f0 <start+0x284e24> @ imm = #0x20424 // System.Boolean UnityEngine.Animation::Play(System.String)
  2714c8: e59f0000     	ldr	r0, [pc]                @ 0x2714d0 <start+0x264a04>
  2714cc: ea000000     	b	0x2714d4 <start+0x264a08> @ imm = #0x0
  2714d0: 004dfd70     	subeq	pc, sp, r0, ror sp
  2714d4: e79f0000     	ldr	r0, [pc, r0]
  2714d8: e3a01000     	mov	r1, #0
  2714dc: e5c01000     	strb	r1, [r0]
  2714e0: e3a00001     	mov	r0, #1
  2714e4: e5ca0078     	strb	r0, [r10, #0x78]
  2714e8: e1a0000a     	mov	r0, r10
  2714ec: e59ae000     	ldr	lr, [r10]
  2714f0: eb008532     	bl	0x2929c0 <start+0x285ef4> @ imm = #0x214c8 // System.Void PauseMenu::HandleButtonMaterials()
  2714f4: e3a00000     	mov	r0, #0
  2714f8: e3a01001     	mov	r1, #1
  2714fc: eb0084cb     	bl	0x292830 <start+0x285d64> @ imm = #0x2132c // System.Void PauseMenu::PlayAnimatingObjects(System.Boolean,System.Boolean)
  271500: e59a0054     	ldr	r0, [r10, #0x54]
  271504: e58a0074     	str	r0, [r10, #0x74]
  271508: e59a6074     	ldr	r6, [r10, #0x74]
  27150c: e1a00006     	mov	r0, r6
  271510: e59a1054     	ldr	r1, [r10, #0x54]
  271514: e1500001     	cmp	r0, r1
  271518: 13a00000     	movne	r0, #0
  27151c: 03a00001     	moveq	r0, #1
  271520: e3500000     	cmp	r0, #0
  271524: 0a000029     	beq	0x2715d0 <start+0x264b04> @ imm = #0xa4
  271528: e1a0000a     	mov	r0, r10
  27152c: e59ae000     	ldr	lr, [r10]
  271530: eb008006     	bl	0x291550 <start+0x284a84> @ imm = #0x20018 // UnityEngine.Animation UnityEngine.Component::get_animation()
  271534: e1a02000     	mov	r2, r0
  271538: e59f1000     	ldr	r1, [pc]                @ 0x271540 <start+0x264a74>
  27153c: ea000000     	b	0x271544 <start+0x264a78> @ imm = #0x0
  271540: 004dfdd0     	<unknown>
  271544: e79f1001     	ldr	r1, [pc, r1]
  271548: e1a00002     	mov	r0, r2
  27154c: e592e000     	ldr	lr, [r2]
  271550: eb0084ce     	bl	0x292890 <start+0x285dc4> @ imm = #0x21338 // UnityEngine.AnimationState UnityEngine.Animation::get_Item(System.String)
  271554: e1a01000     	mov	r1, r0
  271558: e591e000     	ldr	lr, [r1]
  27155c: eb008003     	bl	0x291570 <start+0x284aa4> @ imm = #0x2000c // System.Single UnityEngine.AnimationState::get_time()
  271560: ee020a10     	vmov	s4, r0
  271564: eeb72ac2     	vcvt.f64.f32	d2, s4
  271568: ed9f3a00     	vldr	s6, [pc]                @ 0x271570 <start+0x264aa4>
  27156c: ea000000     	b	0x271574 <start+0x264aa8> @ imm = #0x0
  271570: 3e800000     	cdplo	p0, #0x8, c0, c0, c0, #0x0
  271574: eeb73ac3     	vcvt.f64.f32	d3, s6
  271578: eeb43b42     	vcmp.f64	d3, d2
  27157c: eef1fa10     	vmrs	APSR_nzcv, fpscr
  271580: e3a00000     	mov	r0, #0
  271584: 43a00001     	movmi	r0, #1
  271588: e3500000     	cmp	r0, #0
  27158c: 0a000001     	beq	0x271598 <start+0x264acc> @ imm = #0x4
  271590: e3a00001     	mov	r0, #1
  271594: eb00837d     	bl	0x292390 <start+0x2858c4> @ imm = #0x20df4 // System.Void QuarterTrigger::DisplayBackDrop(System.Boolean)
  271598: e1a0000a     	mov	r0, r10
  27159c: e59ae000     	ldr	lr, [r10]
  2715a0: eb007fea     	bl	0x291550 <start+0x284a84> @ imm = #0x1ffa8 // UnityEngine.Animation UnityEngine.Component::get_animation()
  2715a4: e1a01000     	mov	r1, r0
  2715a8: e591e000     	ldr	lr, [r1]
  2715ac: eb0080cb     	bl	0x2918e0 <start+0x284e14> @ imm = #0x2032c // System.Boolean UnityEngine.Animation::get_isPlaying()
  2715b0: e3500000     	cmp	r0, #0
  2715b4: 1a0000b3     	bne	0x271888 <start+0x264dbc> @ imm = #0x2cc
  2715b8: e1a0000a     	mov	r0, r10
  2715bc: e59ae000     	ldr	lr, [r10]
  2715c0: eb008502     	bl	0x2929d0 <start+0x285f04> @ imm = #0x21408 // System.Void PauseMenu::DisplayHelpButton()
  2715c4: e59a0058     	ldr	r0, [r10, #0x58]
  2715c8: e58a0074     	str	r0, [r10, #0x74]
  2715cc: ea0000ad     	b	0x271888 <start+0x264dbc> @ imm = #0x2b4
  2715d0: e59a005c     	ldr	r0, [r10, #0x5c]
  2715d4: e1560000     	cmp	r6, r0
  2715d8: 13a00000     	movne	r0, #0
  2715dc: 03a00001     	moveq	r0, #1
  2715e0: e3500000     	cmp	r0, #0
  2715e4: 0a000024     	beq	0x27167c <start+0x264bb0> @ imm = #0x90
  2715e8: e1a0000a     	mov	r0, r10
  2715ec: e59ae000     	ldr	lr, [r10]
  2715f0: eb007fd6     	bl	0x291550 <start+0x284a84> @ imm = #0x1ff58 // UnityEngine.Animation UnityEngine.Component::get_animation()
  2715f4: e1a01000     	mov	r1, r0
  2715f8: e591e000     	ldr	lr, [r1]
  2715fc: eb0080b7     	bl	0x2918e0 <start+0x284e14> @ imm = #0x202dc // System.Boolean UnityEngine.Animation::get_isPlaying()
  271600: e3500000     	cmp	r0, #0
  271604: 1a00009f     	bne	0x271888 <start+0x264dbc> @ imm = #0x27c
  271608: e59f0000     	ldr	r0, [pc]                @ 0x271610 <start+0x264b44>
  27160c: ea000000     	b	0x271614 <start+0x264b48> @ imm = #0x0
  271610: 004df3f0     	<unknown>
  271614: e79f0000     	ldr	r0, [pc, r0]
  271618: e5d00000     	ldrb	r0, [r0]
  27161c: e3500000     	cmp	r0, #0
  271620: 1a000003     	bne	0x271634 <start+0x264b68> @ imm = #0xc
  271624: e3a00001     	mov	r0, #1
  271628: e3a01001     	mov	r1, #1
  27162c: eb00847f     	bl	0x292830 <start+0x285d64> @ imm = #0x211fc // System.Void PauseMenu::PlayAnimatingObjects(System.Boolean,System.Boolean)
  271630: ea000002     	b	0x271640 <start+0x264b74> @ imm = #0x8
  271634: e3a00000     	mov	r0, #0
  271638: e3a01001     	mov	r1, #1
  27163c: eb00847b     	bl	0x292830 <start+0x285d64> @ imm = #0x211ec // System.Void PauseMenu::PlayAnimatingObjects(System.Boolean,System.Boolean)
  271640: e59f0000     	ldr	r0, [pc]                @ 0x271648 <start+0x264b7c>
  271644: ea000000     	b	0x27164c <start+0x264b80> @ imm = #0x0
  271648: 004df94c     	subeq	pc, sp, r12, asr #18
  27164c: e79f0000     	ldr	r0, [pc, r0]
  271650: e5d00000     	ldrb	r0, [r0]
  271654: e3500000     	cmp	r0, #0
  271658: 1a000001     	bne	0x271664 <start+0x264b98> @ imm = #0x4
  27165c: e3a00000     	mov	r0, #0
  271660: eb00834a     	bl	0x292390 <start+0x2858c4> @ imm = #0x20d28 // System.Void QuarterTrigger::DisplayBackDrop(System.Boolean)
  271664: e1a0000a     	mov	r0, r10
  271668: e59ae000     	ldr	lr, [r10]
  27166c: eb0084db     	bl	0x2929e0 <start+0x285f14> @ imm = #0x2136c // System.Void PauseMenu::ReturnToGame()
  271670: e59a0050     	ldr	r0, [r10, #0x50]
  271674: e58a0074     	str	r0, [r10, #0x74]
  271678: ea000082     	b	0x271888 <start+0x264dbc> @ imm = #0x208
  27167c: e59a0060     	ldr	r0, [r10, #0x60]
  271680: e1560000     	cmp	r6, r0
  271684: 13a00000     	movne	r0, #0
  271688: 03a00001     	moveq	r0, #1
  27168c: e3500000     	cmp	r0, #0
  271690: 0a00000f     	beq	0x2716d4 <start+0x264c08> @ imm = #0x3c
  271694: e1a0000a     	mov	r0, r10
  271698: e59ae000     	ldr	lr, [r10]
  27169c: eb007fab     	bl	0x291550 <start+0x284a84> @ imm = #0x1feac // UnityEngine.Animation UnityEngine.Component::get_animation()
  2716a0: e1a01000     	mov	r1, r0
  2716a4: e591e000     	ldr	lr, [r1]
  2716a8: eb00808c     	bl	0x2918e0 <start+0x284e14> @ imm = #0x20230 // System.Boolean UnityEngine.Animation::get_isPlaying()
  2716ac: e3500000     	cmp	r0, #0
  2716b0: 1a000074     	bne	0x271888 <start+0x264dbc> @ imm = #0x1d0
  2716b4: e59a2018     	ldr	r2, [r10, #0x18]
  2716b8: e1a00002     	mov	r0, r2
  2716bc: e3a01000     	mov	r1, #0
  2716c0: e592e000     	ldr	lr, [r2]
  2716c4: eb00801d     	bl	0x291740 <start+0x284c74> @ imm = #0x20074 // System.Void UnityEngine.GameObject::SetActiveRecursively(System.Boolean)
  2716c8: e59a0050     	ldr	r0, [r10, #0x50]
  2716cc: e58a0074     	str	r0, [r10, #0x74]
  2716d0: ea00006c     	b	0x271888 <start+0x264dbc> @ imm = #0x1b0
  2716d4: e59a0064     	ldr	r0, [r10, #0x64]
  2716d8: e1560000     	cmp	r6, r0
  2716dc: 13a00000     	movne	r0, #0
  2716e0: 03a00001     	moveq	r0, #1
  2716e4: e3500000     	cmp	r0, #0
  2716e8: 0a000021     	beq	0x271774 <start+0x264ca8> @ imm = #0x84
  2716ec: e1a0000a     	mov	r0, r10
  2716f0: e59ae000     	ldr	lr, [r10]
  2716f4: eb007f95     	bl	0x291550 <start+0x284a84> @ imm = #0x1fe54 // UnityEngine.Animation UnityEngine.Component::get_animation()
  2716f8: e1a01000     	mov	r1, r0
  2716fc: e591e000     	ldr	lr, [r1]
  271700: eb008076     	bl	0x2918e0 <start+0x284e14> @ imm = #0x201d8 // System.Boolean UnityEngine.Animation::get_isPlaying()
  271704: e3500000     	cmp	r0, #0
  271708: 1a00005e     	bne	0x271888 <start+0x264dbc> @ imm = #0x178
  27170c: e59f0000     	ldr	r0, [pc]                @ 0x271714 <start+0x264c48>
  271710: ea000000     	b	0x271718 <start+0x264c4c> @ imm = #0x0
  271714: 004df814     	subeq	pc, sp, r4, lsl r8
  271718: e79f0000     	ldr	r0, [pc, r0]
  27171c: e5901000     	ldr	r1, [r0]
  271720: e59f0000     	ldr	r0, [pc]                @ 0x271728 <start+0x264c5c>
  271724: ea000000     	b	0x27172c <start+0x264c60> @ imm = #0x0
  271728: 004df85c     	subeq	pc, sp, r12, asr r8
  27172c: e79f0000     	ldr	r0, [pc, r0]
  271730: e5801000     	str	r1, [r0]
  271734: e59f0000     	ldr	r0, [pc]                @ 0x27173c <start+0x264c70>
  271738: ea000000     	b	0x271740 <start+0x264c74> @ imm = #0x0
  27173c: 004df924     	subeq	pc, sp, r4, lsr #18
  271740: e79f0000     	ldr	r0, [pc, r0]
  271744: e3a01001     	mov	r1, #1
  271748: e5c01000     	strb	r1, [r0]
  27174c: eb00811f     	bl	0x291bd0 <start+0x285104> @ imm = #0x2047c // System.Void mainmenu::DeleteLastGame()
  271750: e59f0000     	ldr	r0, [pc]                @ 0x271758 <start+0x264c8c>
  271754: ea000000     	b	0x27175c <start+0x264c90> @ imm = #0x0
  271758: 004df4b0     	strheq	pc, [sp], #-64
  27175c: e79f0000     	ldr	r0, [pc, r0]
  271760: e3a01001     	mov	r1, #1
  271764: e5c01000     	strb	r1, [r0]
  271768: e59a0050     	ldr	r0, [r10, #0x50]
  27176c: e58a0074     	str	r0, [r10, #0x74]
  271770: ea000044     	b	0x271888 <start+0x264dbc> @ imm = #0x110
  271774: e59a0068     	ldr	r0, [r10, #0x68]
  271778: e1560000     	cmp	r6, r0
  27177c: 13a00000     	movne	r0, #0
  271780: 03a00001     	moveq	r0, #1
  271784: e3500000     	cmp	r0, #0
  271788: 0a00001b     	beq	0x2717fc <start+0x264d30> @ imm = #0x6c
  27178c: e59a1014     	ldr	r1, [r10, #0x14]
  271790: e1a00001     	mov	r0, r1
  271794: e591e000     	ldr	lr, [r1]
  271798: eb008088     	bl	0x2919c0 <start+0x284ef4> @ imm = #0x20220 // UnityEngine.Animation UnityEngine.GameObject::get_animation()
  27179c: e1a02000     	mov	r2, r0
  2717a0: e59a1048     	ldr	r1, [r10, #0x48]
  2717a4: e1a00002     	mov	r0, r2
  2717a8: e592e000     	ldr	lr, [r2]
  2717ac: eb00809b     	bl	0x291a20 <start+0x284f54> @ imm = #0x2026c // System.Boolean UnityEngine.Animation::IsPlaying(System.String)
  2717b0: e3500000     	cmp	r0, #0
  2717b4: 1a000033     	bne	0x271888 <start+0x264dbc> @ imm = #0xcc
  2717b8: e1a0000a     	mov	r0, r10
  2717bc: e59ae000     	ldr	lr, [r10]
  2717c0: eb00846e     	bl	0x292980 <start+0x285eb4> @ imm = #0x211b8 // System.Void PauseMenu::HideHelpButton()
  2717c4: e1a0000a     	mov	r0, r10
  2717c8: e59ae000     	ldr	lr, [r10]
  2717cc: eb007f5f     	bl	0x291550 <start+0x284a84> @ imm = #0x1fd7c // UnityEngine.Animation UnityEngine.Component::get_animation()
  2717d0: e1a02000     	mov	r2, r0
  2717d4: e59f1000     	ldr	r1, [pc]                @ 0x2717dc <start+0x264d10>
  2717d8: ea000000     	b	0x2717e0 <start+0x264d14> @ imm = #0x0
  2717dc: 004dfb3c     	subeq	pc, sp, r12, lsr r11
  2717e0: e79f1001     	ldr	r1, [pc, r1]
  2717e4: e1a00002     	mov	r0, r2
  2717e8: e592e000     	ldr	lr, [r2]
  2717ec: eb00803f     	bl	0x2918f0 <start+0x284e24> @ imm = #0x200fc // System.Boolean UnityEngine.Animation::Play(System.String)
  2717f0: e59a006c     	ldr	r0, [r10, #0x6c]
  2717f4: e58a0074     	str	r0, [r10, #0x74]
  2717f8: ea000022     	b	0x271888 <start+0x264dbc> @ imm = #0x88
  2717fc: e59a006c     	ldr	r0, [r10, #0x6c]
  271800: e1560000     	cmp	r6, r0
  271804: 13a00000     	movne	r0, #0
  271808: 03a00001     	moveq	r0, #1
  27180c: e3500000     	cmp	r0, #0
  271810: 0a00001c     	beq	0x271888 <start+0x264dbc> @ imm = #0x70
  271814: e1a0000a     	mov	r0, r10
  271818: e59ae000     	ldr	lr, [r10]
  27181c: eb007f4b     	bl	0x291550 <start+0x284a84> @ imm = #0x1fd2c // UnityEngine.Animation UnityEngine.Component::get_animation()
  271820: e1a02000     	mov	r2, r0
  271824: e59f1000     	ldr	r1, [pc]                @ 0x27182c <start+0x264d60>
  271828: ea000000     	b	0x271830 <start+0x264d64> @ imm = #0x0
  27182c: 004dfaec     	subeq	pc, sp, r12, ror #21
  271830: e79f1001     	ldr	r1, [pc, r1]
  271834: e1a00002     	mov	r0, r2
  271838: e592e000     	ldr	lr, [r2]
  27183c: eb008077     	bl	0x291a20 <start+0x284f54> @ imm = #0x201dc // System.Boolean UnityEngine.Animation::IsPlaying(System.String)
  271840: e3500000     	cmp	r0, #0
  271844: 1a00000f     	bne	0x271888 <start+0x264dbc> @ imm = #0x3c
  271848: ebff48f0     	bl	0x243c10 <start+0x237144> @ imm = #-0x2dc40
  27184c: e3500000     	cmp	r0, #0
  271850: 0a000007     	beq	0x271874 <start+0x264da8> @ imm = #0x1c
  271854: e59a1020     	ldr	r1, [r10, #0x20]
  271858: e1a00001     	mov	r0, r1
  27185c: e591e000     	ldr	lr, [r1]
  271860: eb008062     	bl	0x2919f0 <start+0x284f24> @ imm = #0x20188 // UnityEngine.Renderer UnityEngine.GameObject::get_renderer()
  271864: e1a02000     	mov	r2, r0
  271868: e3a01000     	mov	r1, #0
  27186c: e592e000     	ldr	lr, [r2]
  271870: eb008026     	bl	0x291910 <start+0x284e44> @ imm = #0x20098 // System.Void UnityEngine.Renderer::set_enabled(System.Boolean)
  271874: e1a0000a     	mov	r0, r10
  271878: e59ae000     	ldr	lr, [r10]
  27187c: eb00845b     	bl	0x2929f0 <start+0x285f24> @ imm = #0x2116c // System.Void PauseMenu::DisplayHelpScreen()
  271880: e59a0070     	ldr	r0, [r10, #0x70]
  271884: e58a0074     	str	r0, [r10, #0x74]
  271888: e28bd000     	add	sp, r11, #0
  27188c: e8bd0d40     	pop	{r6, r8, r10, r11}
  271890: e59d7008     	ldr	r7, [sp, #0x8]
  271894: e89da000     	ldm	sp, {sp, pc}
