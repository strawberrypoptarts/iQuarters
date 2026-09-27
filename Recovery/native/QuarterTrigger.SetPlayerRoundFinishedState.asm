
/Users/tomato/Documents/Codex/iQuarters/Recovery/native/iquarters-armv7:	file format mach-o arm

Disassembly of section __TEXT,__text:

0000cacc <start>:
  2541f0: e1a0c00d     	mov	r12, sp
  2541f4: e92d4080     	push	{r7, lr}
  2541f8: e1a0700d     	mov	r7, sp
  2541fc: e92d5d60     	push	{r5, r6, r8, r10, r11, r12, lr}
  254200: e24dd034     	sub	sp, sp, #52
  254204: e1a0b00d     	mov	r11, sp
  254208: e1a05000     	mov	r5, r0
  25420c: e1a06001     	mov	r6, r1
  254210: e1a0a002     	mov	r10, r2
  254214: e3a00000     	mov	r0, #0
  254218: e5cb000d     	strb	r0, [r11, #0xd]
  25421c: e1a0000a     	mov	r0, r10
  254220: eb00f876     	bl	0x292400 <start+0x285934> @ imm = #0x3e1d8 // System.Int32 GameManagerScript::GetPlayerScore(System.Int32)
  254224: e1a0000a     	mov	r0, r10
  254228: eb00f878     	bl	0x292410 <start+0x285944> @ imm = #0x3e1e0 // System.String GameManagerScript::GetName(System.Int32)
  25422c: e58b0008     	str	r0, [r11, #0x8]
  254230: e3a00000     	mov	r0, #0
  254234: e5cb000c     	strb	r0, [r11, #0xc]
  254238: e59f0000     	ldr	r0, [pc]                @ 0x254240 <start+0x247774>
  25423c: ea000000     	b	0x254244 <start+0x247778> @ imm = #0x0
  254240: 004fc7c4     	subeq	r12, pc, r4, asr #15
  254244: e79f0000     	ldr	r0, [pc, r0]
  254248: e5900000     	ldr	r0, [r0]
  25424c: e59f1000     	ldr	r1, [pc]                @ 0x254254 <start+0x247788>
  254250: ea000000     	b	0x254258 <start+0x24778c> @ imm = #0x0
  254254: 004fc9ac     	subeq	r12, pc, r12, lsr #19
  254258: e79f1001     	ldr	r1, [pc, r1]
  25425c: e5911000     	ldr	r1, [r1]
  254260: e1500001     	cmp	r0, r1
  254264: 13a00000     	movne	r0, #0
  254268: 03a00001     	moveq	r0, #1
  25426c: e3500000     	cmp	r0, #0
  254270: 0a0000c7     	beq	0x254594 <start+0x247ac8> @ imm = #0x31c
  254274: e59f0000     	ldr	r0, [pc]                @ 0x25427c <start+0x2477b0>
  254278: ea000000     	b	0x254280 <start+0x2477b4> @ imm = #0x0
  25427c: 004fcb8c     	subeq	r12, pc, r12, lsl #23
  254280: e79f0000     	ldr	r0, [pc, r0]
  254284: e5d00000     	ldrb	r0, [r0]
  254288: e3500000     	cmp	r0, #0
  25428c: 0a00002c     	beq	0x254344 <start+0x247878> @ imm = #0xb0
  254290: e59f0000     	ldr	r0, [pc]                @ 0x254298 <start+0x2477cc>
  254294: ea000000     	b	0x25429c <start+0x2477d0> @ imm = #0x0
  254298: 004fcb78     	subeq	r12, pc, r8, ror r11
  25429c: e79f0000     	ldr	r0, [pc, r0]
  2542a0: e5900000     	ldr	r0, [r0]
  2542a4: e1560000     	cmp	r6, r0
  2542a8: 13a00000     	movne	r0, #0
  2542ac: 03a00001     	moveq	r0, #1
  2542b0: e3500000     	cmp	r0, #0
  2542b4: 0a000022     	beq	0x254344 <start+0x247878> @ imm = #0x88
  2542b8: e595208c     	ldr	r2, [r5, #0x8c]
  2542bc: e1a00002     	mov	r0, r2
  2542c0: e3a01001     	mov	r1, #1
  2542c4: e592e000     	ldr	lr, [r2]
  2542c8: eb00f51c     	bl	0x291740 <start+0x284c74> @ imm = #0x3d470 // System.Void UnityEngine.GameObject::SetActiveRecursively(System.Boolean)
  2542cc: e59f0000     	ldr	r0, [pc]                @ 0x2542d4 <start+0x247808>
  2542d0: ea000000     	b	0x2542d8 <start+0x24780c> @ imm = #0x0
  2542d4: 004fc8d4     	ldrdeq	r12, sp, [pc], #-132
  2542d8: e79f0000     	ldr	r0, [pc, r0]
  2542dc: e3a01001     	mov	r1, #1
  2542e0: e5c01000     	strb	r1, [r0]
  2542e4: e59f0000     	ldr	r0, [pc]                @ 0x2542ec <start+0x247820>
  2542e8: ea000000     	b	0x2542f0 <start+0x247824> @ imm = #0x0
  2542ec: 004fc714     	subeq	r12, pc, r4, lsl r7
  2542f0: e79f0000     	ldr	r0, [pc, r0]
  2542f4: e5d00000     	ldrb	r0, [r0]
  2542f8: e3500000     	cmp	r0, #0
  2542fc: 1a00000d     	bne	0x254338 <start+0x24786c> @ imm = #0x34
  254300: e1a00005     	mov	r0, r5
  254304: e595e000     	ldr	lr, [r5]
  254308: eb00f478     	bl	0x2914f0 <start+0x284a24> @ imm = #0x3d1e0 // UnityEngine.AudioSource UnityEngine.Component::get_audio()
  25430c: e1a02000     	mov	r2, r0
  254310: e5951038     	ldr	r1, [r5, #0x38]
  254314: e1a00002     	mov	r0, r2
  254318: e592e000     	ldr	lr, [r2]
  25431c: eb00f477     	bl	0x291500 <start+0x284a34> @ imm = #0x3d1dc // System.Void UnityEngine.AudioSource::set_clip(UnityEngine.AudioClip)
  254320: e1a00005     	mov	r0, r5
  254324: e595e000     	ldr	lr, [r5]
  254328: eb00f470     	bl	0x2914f0 <start+0x284a24> @ imm = #0x3d1c0 // UnityEngine.AudioSource UnityEngine.Component::get_audio()
  25432c: e1a01000     	mov	r1, r0
  254330: e591e000     	ldr	lr, [r1]
  254334: eb00f475     	bl	0x291510 <start+0x284a44> @ imm = #0x3d1d4 // System.Void UnityEngine.AudioSource::Play()
  254338: e3a00001     	mov	r0, #1
  25433c: e5cb000c     	strb	r0, [r11, #0xc]
  254340: ea00003c     	b	0x254438 <start+0x24796c> @ imm = #0xf0
  254344: e59f0000     	ldr	r0, [pc]                @ 0x25434c <start+0x247880>
  254348: ea000000     	b	0x254350 <start+0x247884> @ imm = #0x0
  25434c: 004fcac0     	subeq	r12, pc, r0, asr #21
  254350: e79f0000     	ldr	r0, [pc, r0]
  254354: e5900000     	ldr	r0, [r0]
  254358: e1560000     	cmp	r6, r0
  25435c: 13a00000     	movne	r0, #0
  254360: 03a00001     	moveq	r0, #1
  254364: e3500000     	cmp	r0, #0
  254368: 0a000020     	beq	0x2543f0 <start+0x247924> @ imm = #0x80
  25436c: e595208c     	ldr	r2, [r5, #0x8c]
  254370: e1a00002     	mov	r0, r2
  254374: e3a01001     	mov	r1, #1
  254378: e592e000     	ldr	lr, [r2]
  25437c: eb00f4ef     	bl	0x291740 <start+0x284c74> @ imm = #0x3d3bc // System.Void UnityEngine.GameObject::SetActiveRecursively(System.Boolean)
  254380: e59f0000     	ldr	r0, [pc]                @ 0x254388 <start+0x2478bc>
  254384: ea000000     	b	0x25438c <start+0x2478c0> @ imm = #0x0
  254388: 004fc824     	subeq	r12, pc, r4, lsr #16
  25438c: e79f0000     	ldr	r0, [pc, r0]
  254390: e3a01001     	mov	r1, #1
  254394: e5c01000     	strb	r1, [r0]
  254398: e59f0000     	ldr	r0, [pc]                @ 0x2543a0 <start+0x2478d4>
  25439c: ea000000     	b	0x2543a4 <start+0x2478d8> @ imm = #0x0
  2543a0: 004fc660     	subeq	r12, pc, r0, ror #12
  2543a4: e79f0000     	ldr	r0, [pc, r0]
  2543a8: e5d00000     	ldrb	r0, [r0]
  2543ac: e3500000     	cmp	r0, #0
  2543b0: 1a000020     	bne	0x254438 <start+0x24796c> @ imm = #0x80
  2543b4: e1a00005     	mov	r0, r5
  2543b8: e595e000     	ldr	lr, [r5]
  2543bc: eb00f44b     	bl	0x2914f0 <start+0x284a24> @ imm = #0x3d12c // UnityEngine.AudioSource UnityEngine.Component::get_audio()
  2543c0: e1a02000     	mov	r2, r0
  2543c4: e5951038     	ldr	r1, [r5, #0x38]
  2543c8: e1a00002     	mov	r0, r2
  2543cc: e592e000     	ldr	lr, [r2]
  2543d0: eb00f44a     	bl	0x291500 <start+0x284a34> @ imm = #0x3d128 // System.Void UnityEngine.AudioSource::set_clip(UnityEngine.AudioClip)
  2543d4: e1a00005     	mov	r0, r5
  2543d8: e595e000     	ldr	lr, [r5]
  2543dc: eb00f443     	bl	0x2914f0 <start+0x284a24> @ imm = #0x3d10c // UnityEngine.AudioSource UnityEngine.Component::get_audio()
  2543e0: e1a01000     	mov	r1, r0
  2543e4: e591e000     	ldr	lr, [r1]
  2543e8: eb00f448     	bl	0x291510 <start+0x284a44> @ imm = #0x3d120 // System.Void UnityEngine.AudioSource::Play()
  2543ec: ea000011     	b	0x254438 <start+0x24796c> @ imm = #0x44
  2543f0: e59520b4     	ldr	r2, [r5, #0xb4]
  2543f4: e1a00002     	mov	r0, r2
  2543f8: e3a01001     	mov	r1, #1
  2543fc: e592e000     	ldr	lr, [r2]
  254400: eb00f4ce     	bl	0x291740 <start+0x284c74> @ imm = #0x3d338 // System.Void UnityEngine.GameObject::SetActiveRecursively(System.Boolean)
  254404: e3a00001     	mov	r0, #1
  254408: e5cb000c     	strb	r0, [r11, #0xc]
  25440c: e59f0000     	ldr	r0, [pc]                @ 0x254414 <start+0x247948>
  254410: ea000000     	b	0x254418 <start+0x24794c> @ imm = #0x0
  254414: 004fc700     	subeq	r12, pc, r0, lsl #14
  254418: e79f0000     	ldr	r0, [pc, r0]
  25441c: e5806000     	str	r6, [r0]
  254420: e5951310     	ldr	r1, [r5, #0x310]
  254424: e59f0000     	ldr	r0, [pc]                @ 0x25442c <start+0x247960>
  254428: ea000000     	b	0x254430 <start+0x247964> @ imm = #0x0
  25442c: 004fc6dc     	ldrdeq	r12, sp, [pc], #-108
  254430: e79f0000     	ldr	r0, [pc, r0]
  254434: e5801000     	str	r1, [r0]
  254438: e5db000c     	ldrb	r0, [r11, #0xc]
  25443c: e3500001     	cmp	r0, #1
  254440: 13a00000     	movne	r0, #0
  254444: 03a00001     	moveq	r0, #1
  254448: e3500000     	cmp	r0, #0
  25444c: 0a00006c     	beq	0x254604 <start+0x247b38> @ imm = #0x1b0
  254450: e5950310     	ldr	r0, [r5, #0x310]
  254454: ee000a10     	vmov	s0, r0
  254458: eeb80ac0     	vcvt.f32.s32	s0, s0
  25445c: eeb72ac0     	vcvt.f64.f32	d2, s0
  254460: e1a00006     	mov	r0, r6
  254464: eeb70bc2     	vcvt.f32.f64	s0, d2
  254468: ed0d0a02     	vstr	s0, [sp, #-8]
  25446c: e51d1008     	ldr	r1, [sp, #-0x8]
  254470: e59b2008     	ldr	r2, [r11, #0x8]
  254474: eb00f7e9     	bl	0x292420 <start+0x285954> @ imm = #0x3dfa4 // System.Boolean HiScoreRoundScript::AddRoundHiScore(System.Int32,System.Single,System.String)
  254478: e5cb000d     	strb	r0, [r11, #0xd]
  25447c: e20000ff     	and	r0, r0, #255
  254480: e3500000     	cmp	r0, #0
  254484: 0a000000     	beq	0x25448c <start+0x2479c0> @ imm = #0x0
  254488: eb00f7e8     	bl	0x292430 <start+0x285964> @ imm = #0x3dfa0 // System.Void HiScoreRoundScript::SaveEntries()
  25448c: e1a00006     	mov	r0, r6
  254490: eb00f7ea     	bl	0x292440 <start+0x285974> @ imm = #0x3dfa8 // System.Void HiScoreScript::UpdateLockedRoundIndex(System.Int32)
  254494: e59502e8     	ldr	r0, [r5, #0x2e8]
  254498: e59f1000     	ldr	r1, [pc]                @ 0x2544a0 <start+0x2479d4>
  25449c: ea000000     	b	0x2544a4 <start+0x2479d8> @ imm = #0x0
  2544a0: 004fc950     	subeq	r12, pc, r0, asr r9
  2544a4: e79f1001     	ldr	r1, [pc, r1]
  2544a8: e5911000     	ldr	r1, [r1]
  2544ac: e0000001     	and	r0, r0, r1
  2544b0: e3500000     	cmp	r0, #0
  2544b4: 1a000008     	bne	0x2544dc <start+0x247a10> @ imm = #0x20
  2544b8: e59502e8     	ldr	r0, [r5, #0x2e8]
  2544bc: e59f1000     	ldr	r1, [pc]                @ 0x2544c4 <start+0x2479f8>
  2544c0: ea000000     	b	0x2544c8 <start+0x2479fc> @ imm = #0x0
  2544c4: 004fc934     	subeq	r12, pc, r4, lsr r9
  2544c8: e79f1001     	ldr	r1, [pc, r1]
  2544cc: e5911000     	ldr	r1, [r1]
  2544d0: e0000001     	and	r0, r0, r1
  2544d4: e3500000     	cmp	r0, #0
  2544d8: 0a000049     	beq	0x254604 <start+0x247b38> @ imm = #0x124
  2544dc: e1a0000a     	mov	r0, r10
  2544e0: eb00f652     	bl	0x291e30 <start+0x285364> @ imm = #0x3d948 // System.Int32 GameManagerScript::GetPlayerShotsLeft(System.Int32)
  2544e4: e58b0010     	str	r0, [r11, #0x10]
  2544e8: e3a01005     	mov	r1, #5
  2544ec: eb00f50b     	bl	0x291920 <start+0x284e54> @ imm = #0x3d42c
  2544f0: e1a0100a     	mov	r1, r10
  2544f4: eb00f7d5     	bl	0x292450 <start+0x285984> @ imm = #0x3df54 // System.Int32 GameManagerScript::AddPlayerScore(System.Int32,System.Int32)
  2544f8: e1a0000a     	mov	r0, r10
  2544fc: eb00f7bf     	bl	0x292400 <start+0x285934> @ imm = #0x3defc // System.Int32 GameManagerScript::GetPlayerScore(System.Int32)
  254500: ee000a10     	vmov	s0, r0
  254504: eeb80ac0     	vcvt.f32.s32	s0, s0
  254508: eeb72ac0     	vcvt.f64.f32	d2, s0
  25450c: ed8b2b06     	vstr	d2, [r11, #24]
  254510: e59f0000     	ldr	r0, [pc]                @ 0x254518 <start+0x247a4c>
  254514: ea000000     	b	0x25451c <start+0x247a50> @ imm = #0x0
  254518: 004fcae4     	subeq	r12, pc, r4, ror #21
  25451c: e79f0000     	ldr	r0, [pc, r0]
  254520: e58b0020     	str	r0, [r11, #0x20]
  254524: e3a00001     	mov	r0, #1
  254528: e09a0000     	adds	r0, r10, r0
  25452c: e58b0024     	str	r0, [r11, #0x24]
  254530: 6b000086     	blvs	0x254750 <start+0x247c84> @ imm = #0x218
  254534: e59f0000     	ldr	r0, [pc]                @ 0x25453c <start+0x247a70>
  254538: ea000000     	b	0x254540 <start+0x247a74> @ imm = #0x0
  25453c: 004fc640     	subeq	r12, pc, r0, asr #12
  254540: e79f0000     	ldr	r0, [pc, r0]
  254544: eb00f511     	bl	0x291990 <start+0x284ec4> @ imm = #0x3d444
  254548: e1a01000     	mov	r1, r0
  25454c: e59b0020     	ldr	r0, [r11, #0x20]
  254550: e59b2024     	ldr	r2, [r11, #0x24]
  254554: e5812008     	str	r2, [r1, #0x8]
  254558: eb00f510     	bl	0x2919a0 <start+0x284ed4> @ imm = #0x3d440
  25455c: e1a01000     	mov	r1, r0
  254560: ed9b2b06     	vldr	d2, [r11, #24]
  254564: eeb70bc2     	vcvt.f32.f64	s0, d2
  254568: ed0d0a02     	vstr	s0, [sp, #-8]
  25456c: e51d0008     	ldr	r0, [sp, #-0x8]
  254570: eb00f7ba     	bl	0x292460 <start+0x285994> @ imm = #0x3dee8 // System.Int32 HiScoreScript::InsertHiScore(System.Single,System.String)
  254574: e1a01000     	mov	r1, r0
  254578: e59f0000     	ldr	r0, [pc]                @ 0x254580 <start+0x247ab4>
  25457c: ea000000     	b	0x254584 <start+0x247ab8> @ imm = #0x0
  254580: 004fc914     	subeq	r12, pc, r4, lsl r9
  254584: e79f0000     	ldr	r0, [pc, r0]
  254588: e5801000     	str	r1, [r0]
  25458c: eb00f7b7     	bl	0x292470 <start+0x2859a4> @ imm = #0x3dedc // System.Void HiScoreScript::SaveEntries()
  254590: ea00001b     	b	0x254604 <start+0x247b38> @ imm = #0x6c
  254594: e5950310     	ldr	r0, [r5, #0x310]
  254598: e58b0028     	str	r0, [r11, #0x28]
  25459c: e1a00006     	mov	r0, r6
  2545a0: eb00f57a     	bl	0x291b90 <start+0x2850c4> @ imm = #0x3d5e8 // System.Int32 HiScoreRoundScript::GetScore(System.Int32)
  2545a4: e1a01000     	mov	r1, r0
  2545a8: e59b0028     	ldr	r0, [r11, #0x28]
  2545ac: e1500001     	cmp	r0, r1
  2545b0: e3a00000     	mov	r0, #0
  2545b4: c3a00001     	movgt	r0, #1
  2545b8: e3500000     	cmp	r0, #0
  2545bc: 0a000010     	beq	0x254604 <start+0x247b38> @ imm = #0x40
  2545c0: e59520b0     	ldr	r2, [r5, #0xb0]
  2545c4: e1a00002     	mov	r0, r2
  2545c8: e3a01001     	mov	r1, #1
  2545cc: e592e000     	ldr	lr, [r2]
  2545d0: eb00f45a     	bl	0x291740 <start+0x284c74> @ imm = #0x3d168 // System.Void UnityEngine.GameObject::SetActiveRecursively(System.Boolean)
  2545d4: e59f0000     	ldr	r0, [pc]                @ 0x2545dc <start+0x247b10>
  2545d8: ea000000     	b	0x2545e0 <start+0x247b14> @ imm = #0x0
  2545dc: 004fc5ac     	subeq	r12, pc, r12, lsr #11
  2545e0: e79f0000     	ldr	r0, [pc, r0]
  2545e4: e3a01001     	mov	r1, #1
  2545e8: e5c01000     	strb	r1, [r0]
  2545ec: e5951310     	ldr	r1, [r5, #0x310]
  2545f0: e59f0000     	ldr	r0, [pc]                @ 0x2545f8 <start+0x247b2c>
  2545f4: ea000000     	b	0x2545fc <start+0x247b30> @ imm = #0x0
  2545f8: 004fc58c     	subeq	r12, pc, r12, lsl #11
  2545fc: e79f0000     	ldr	r0, [pc, r0]
  254600: e5801000     	str	r1, [r0]
  254604: e5db000d     	ldrb	r0, [r11, #0xd]
  254608: e3500000     	cmp	r0, #0
  25460c: 1a000006     	bne	0x25462c <start+0x247b60> @ imm = #0x18
  254610: e59f0000     	ldr	r0, [pc]                @ 0x254618 <start+0x247b4c>
  254614: ea000000     	b	0x25461c <start+0x247b50> @ imm = #0x0
  254618: 004fc4f4     	strdeq	r12, sp, [pc], #-68
  25461c: e79f0000     	ldr	r0, [pc, r0]
  254620: e3a01001     	mov	r1, #1
  254624: e5c01000     	strb	r1, [r0]
  254628: ea000005     	b	0x254644 <start+0x247b78> @ imm = #0x14
  25462c: e59f0000     	ldr	r0, [pc]                @ 0x254634 <start+0x247b68>
  254630: ea000000     	b	0x254638 <start+0x247b6c> @ imm = #0x0
  254634: 004fc4dc     	ldrdeq	r12, sp, [pc], #-76
  254638: e79f0000     	ldr	r0, [pc, r0]
  25463c: e3a01001     	mov	r1, #1
  254640: e5c01000     	strb	r1, [r0]
  254644: e5950348     	ldr	r0, [r5, #0x348]
  254648: e3500001     	cmp	r0, #1
  25464c: e3a00000     	mov	r0, #0
  254650: c3a00001     	movgt	r0, #1
  254654: e3500000     	cmp	r0, #0
  254658: 13a00000     	movne	r0, #0
  25465c: 03a00001     	moveq	r0, #1
  254660: e3500000     	cmp	r0, #0
  254664: 0a000005     	beq	0x254680 <start+0x247bb4> @ imm = #0x14
  254668: e59f0000     	ldr	r0, [pc]                @ 0x254670 <start+0x247ba4>
  25466c: ea000000     	b	0x254674 <start+0x247ba8> @ imm = #0x0
  254670: 004fc990     	<unknown>
  254674: e79f0000     	ldr	r0, [pc, r0]
  254678: e3a01001     	mov	r1, #1
  25467c: e5c01000     	strb	r1, [r0]
  254680: e59f0000     	ldr	r0, [pc]                @ 0x254688 <start+0x247bbc>
  254684: ea000000     	b	0x25468c <start+0x247bc0> @ imm = #0x0
  254688: 004fc8d8     	ldrdeq	r12, sp, [pc], #-136
  25468c: e79f0000     	ldr	r0, [pc, r0]
  254690: e5901000     	ldr	r1, [r0]
  254694: e59f0000     	ldr	r0, [pc]                @ 0x25469c <start+0x247bd0>
  254698: ea000000     	b	0x2546a0 <start+0x247bd4> @ imm = #0x0
  25469c: 004fc8e8     	subeq	r12, pc, r8, ror #17
  2546a0: e79f0000     	ldr	r0, [pc, r0]
  2546a4: e5801000     	str	r1, [r0]
  2546a8: e59f0000     	ldr	r0, [pc]                @ 0x2546b0 <start+0x247be4>
  2546ac: ea000000     	b	0x2546b4 <start+0x247be8> @ imm = #0x0
  2546b0: 004fc354     	subeq	r12, pc, r4, asr r3
  2546b4: e79f0000     	ldr	r0, [pc, r0]
  2546b8: e5900000     	ldr	r0, [r0]
  2546bc: e59f1000     	ldr	r1, [pc]                @ 0x2546c4 <start+0x247bf8>
  2546c0: ea000000     	b	0x2546c8 <start+0x247bfc> @ imm = #0x0
  2546c4: 004fc344     	subeq	r12, pc, r4, asr #6
  2546c8: e79f1001     	ldr	r1, [pc, r1]
  2546cc: e5911000     	ldr	r1, [r1]
  2546d0: e1500001     	cmp	r0, r1
  2546d4: 13a00000     	movne	r0, #0
  2546d8: 03a00001     	moveq	r0, #1
  2546dc: e3500000     	cmp	r0, #0
  2546e0: 0a00000c     	beq	0x254718 <start+0x247c4c> @ imm = #0x30
  2546e4: e59f0000     	ldr	r0, [pc]                @ 0x2546ec <start+0x247c20>
  2546e8: ea000000     	b	0x2546f0 <start+0x247c24> @ imm = #0x0
  2546ec: 004fc49c     	<unknown>
  2546f0: e79f0000     	ldr	r0, [pc, r0]
  2546f4: e5d00000     	ldrb	r0, [r0]
  2546f8: e3500000     	cmp	r0, #0
  2546fc: 1a000005     	bne	0x254718 <start+0x247c4c> @ imm = #0x14
  254700: eb00f3e6     	bl	0x2916a0 <start+0x284bd4> @ imm = #0x3cf98 // System.Single UnityEngine.Time::get_time()
  254704: ee020a10     	vmov	s4, r0
  254708: eeb72ac2     	vcvt.f64.f32	d2, s4
  25470c: eeb70bc2     	vcvt.f32.f64	s0, d2
  254710: ed850ae5     	vstr	s0, [r5, #916]
  254714: ea000009     	b	0x254740 <start+0x247c74> @ imm = #0x24
  254718: eb00f3e0     	bl	0x2916a0 <start+0x284bd4> @ imm = #0x3cf80 // System.Single UnityEngine.Time::get_time()
  25471c: ee020a10     	vmov	s4, r0
  254720: eeb72ac2     	vcvt.f64.f32	d2, s4
  254724: ed9f3a00     	vldr	s6, [pc]                @ 0x25472c <start+0x247c60>
  254728: ea000000     	b	0x254730 <start+0x247c64> @ imm = #0x0
  25472c: 40100000     	andsmi	r0, r0, r0
  254730: eeb73ac3     	vcvt.f64.f32	d3, s6
  254734: ee322b03     	vadd.f64	d2, d2, d3
  254738: eeb70bc2     	vcvt.f32.f64	s0, d2
  25473c: ed850ae5     	vstr	s0, [r5, #916]
  254740: e28bd034     	add	sp, r11, #52
  254744: e8bd0d60     	pop	{r5, r6, r8, r10, r11}
  254748: e59d7008     	ldr	r7, [sp, #0x8]
  25474c: e89da000     	ldm	sp, {sp, pc}
  254750: e1a0100e     	mov	r1, lr
  254754: e59f0000     	ldr	r0, [pc]                @ 0x25475c <start+0x247c90>
  254758: eb00f378     	bl	0x291540 <start+0x284a74> @ imm = #0x3cde0
  25475c: 020000fd     	andeq	r0, r0, #253
