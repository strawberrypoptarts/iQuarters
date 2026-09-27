
/Users/tomato/Documents/Codex/iQuarters/Recovery/native/iquarters-armv7:	file format mach-o arm

Disassembly of section __TEXT,__text:

0000cacc <start>:
  2597a4: e1a0c00d     	mov	r12, sp
  2597a8: e92d4080     	push	{r7, lr}
  2597ac: e1a0700d     	mov	r7, sp
  2597b0: e92d5d00     	push	{r8, r10, r11, r12, lr}
  2597b4: e24dd00c     	sub	sp, sp, #12
  2597b8: e1a0b00d     	mov	r11, sp
  2597bc: e58b0004     	str	r0, [r11, #0x4]
  2597c0: e1a0a001     	mov	r10, r1
  2597c4: e59f0000     	ldr	r0, [pc]                @ 0x2597cc <start+0x24cd00>
  2597c8: ea000000     	b	0x2597d0 <start+0x24cd04> @ imm = #0x0
  2597cc: 004f7860     	subeq	r7, pc, r0, ror #16
  2597d0: e79f0000     	ldr	r0, [pc, r0]
  2597d4: e5900000     	ldr	r0, [r0]
  2597d8: e3500003     	cmp	r0, #3
  2597dc: 13a00000     	movne	r0, #0
  2597e0: 03a00001     	moveq	r0, #1
  2597e4: e3500000     	cmp	r0, #0
  2597e8: 0a000005     	beq	0x259804 <start+0x24cd38> @ imm = #0x14
  2597ec: e59f0000     	ldr	r0, [pc]                @ 0x2597f4 <start+0x24cd28>
  2597f0: ea000000     	b	0x2597f8 <start+0x24cd2c> @ imm = #0x0
  2597f4: 004f7714     	subeq	r7, pc, r4, lsl r7
  2597f8: e79f0000     	ldr	r0, [pc, r0]
  2597fc: e590a000     	ldr	r10, [r0]
  259800: ea00006b     	b	0x2599b4 <start+0x24cee8> @ imm = #0x1ac
  259804: e59f0000     	ldr	r0, [pc]                @ 0x25980c <start+0x24cd40>
  259808: ea000000     	b	0x259810 <start+0x24cd44> @ imm = #0x0
  25980c: 004f7820     	subeq	r7, pc, r0, lsr #16
  259810: e79f0000     	ldr	r0, [pc, r0]
  259814: e5900000     	ldr	r0, [r0]
  259818: e3500006     	cmp	r0, #6
  25981c: 13a00000     	movne	r0, #0
  259820: 03a00001     	moveq	r0, #1
  259824: e3500000     	cmp	r0, #0
  259828: 0a000005     	beq	0x259844 <start+0x24cd78> @ imm = #0x14
  25982c: e59f0000     	ldr	r0, [pc]                @ 0x259834 <start+0x24cd68>
  259830: ea000000     	b	0x259838 <start+0x24cd6c> @ imm = #0x0
  259834: 004f76d4     	ldrdeq	r7, r8, [pc], #-100
  259838: e79f0000     	ldr	r0, [pc, r0]
  25983c: e590a000     	ldr	r10, [r0]
  259840: ea00005b     	b	0x2599b4 <start+0x24cee8> @ imm = #0x16c
  259844: e59f0000     	ldr	r0, [pc]                @ 0x25984c <start+0x24cd80>
  259848: ea000000     	b	0x259850 <start+0x24cd84> @ imm = #0x0
  25984c: 004f77e0     	subeq	r7, pc, r0, ror #15
  259850: e79f0000     	ldr	r0, [pc, r0]
  259854: e5900000     	ldr	r0, [r0]
  259858: e3500008     	cmp	r0, #8
  25985c: 13a00000     	movne	r0, #0
  259860: 03a00001     	moveq	r0, #1
  259864: e3500000     	cmp	r0, #0
  259868: 0a000014     	beq	0x2598c0 <start+0x24cdf4> @ imm = #0x50
  25986c: e59f0000     	ldr	r0, [pc]                @ 0x259874 <start+0x24cda8>
  259870: ea000000     	b	0x259878 <start+0x24cdac> @ imm = #0x0
  259874: 004f769c     	<unknown>
  259878: e79f0000     	ldr	r0, [pc, r0]
  25987c: e5900000     	ldr	r0, [r0]
  259880: e59f1000     	ldr	r1, [pc]                @ 0x259888 <start+0x24cdbc>
  259884: ea000000     	b	0x25988c <start+0x24cdc0> @ imm = #0x0
  259888: 004f7678     	subeq	r7, pc, r8, ror r6
  25988c: e79f1001     	ldr	r1, [pc, r1]
  259890: e5911000     	ldr	r1, [r1]
  259894: e1500001     	cmp	r0, r1
  259898: 13a00000     	movne	r0, #0
  25989c: 03a00001     	moveq	r0, #1
  2598a0: e3500000     	cmp	r0, #0
  2598a4: 0a000005     	beq	0x2598c0 <start+0x24cdf4> @ imm = #0x14
  2598a8: e59f0000     	ldr	r0, [pc]                @ 0x2598b0 <start+0x24cde4>
  2598ac: ea000000     	b	0x2598b4 <start+0x24cde8> @ imm = #0x0
  2598b0: 004f7654     	subeq	r7, pc, r4, asr r6
  2598b4: e79f0000     	ldr	r0, [pc, r0]
  2598b8: e590a000     	ldr	r10, [r0]
  2598bc: ea00003c     	b	0x2599b4 <start+0x24cee8> @ imm = #0xf0
  2598c0: e59f0000     	ldr	r0, [pc]                @ 0x2598c8 <start+0x24cdfc>
  2598c4: ea000000     	b	0x2598cc <start+0x24ce00> @ imm = #0x0
  2598c8: 004f7764     	subeq	r7, pc, r4, ror #14
  2598cc: e79f0000     	ldr	r0, [pc, r0]
  2598d0: e5900000     	ldr	r0, [r0]
  2598d4: e350000a     	cmp	r0, #10
  2598d8: 13a00000     	movne	r0, #0
  2598dc: 03a00001     	moveq	r0, #1
  2598e0: e3500000     	cmp	r0, #0
  2598e4: 0a000014     	beq	0x25993c <start+0x24ce70> @ imm = #0x50
  2598e8: e59f0000     	ldr	r0, [pc]                @ 0x2598f0 <start+0x24ce24>
  2598ec: ea000000     	b	0x2598f4 <start+0x24ce28> @ imm = #0x0
  2598f0: 004f7620     	subeq	r7, pc, r0, lsr #12
  2598f4: e79f0000     	ldr	r0, [pc, r0]
  2598f8: e5900000     	ldr	r0, [r0]
  2598fc: e59f1000     	ldr	r1, [pc]                @ 0x259904 <start+0x24ce38>
  259900: ea000000     	b	0x259908 <start+0x24ce3c> @ imm = #0x0
  259904: 004f7604     	subeq	r7, pc, r4, lsl #12
  259908: e79f1001     	ldr	r1, [pc, r1]
  25990c: e5911000     	ldr	r1, [r1]
  259910: e1500001     	cmp	r0, r1
  259914: 13a00000     	movne	r0, #0
  259918: 03a00001     	moveq	r0, #1
  25991c: e3500000     	cmp	r0, #0
  259920: 0a000005     	beq	0x25993c <start+0x24ce70> @ imm = #0x14
  259924: e59f0000     	ldr	r0, [pc]                @ 0x25992c <start+0x24ce60>
  259928: ea000000     	b	0x259930 <start+0x24ce64> @ imm = #0x0
  25992c: 004f75d4     	ldrdeq	r7, r8, [pc], #-84
  259930: e79f0000     	ldr	r0, [pc, r0]
  259934: e590a000     	ldr	r10, [r0]
  259938: ea00001d     	b	0x2599b4 <start+0x24cee8> @ imm = #0x74
  25993c: e59f0000     	ldr	r0, [pc]                @ 0x259944 <start+0x24ce78>
  259940: ea000000     	b	0x259948 <start+0x24ce7c> @ imm = #0x0
  259944: 004f76e8     	subeq	r7, pc, r8, ror #13
  259948: e79f0000     	ldr	r0, [pc, r0]
  25994c: e5900000     	ldr	r0, [r0]
  259950: e350000c     	cmp	r0, #12
  259954: 13a00000     	movne	r0, #0
  259958: 03a00001     	moveq	r0, #1
  25995c: e3500000     	cmp	r0, #0
  259960: 0a000013     	beq	0x2599b4 <start+0x24cee8> @ imm = #0x4c
  259964: e59f0000     	ldr	r0, [pc]                @ 0x25996c <start+0x24cea0>
  259968: ea000000     	b	0x259970 <start+0x24cea4> @ imm = #0x0
  25996c: 004f75a4     	subeq	r7, pc, r4, lsr #11
  259970: e79f0000     	ldr	r0, [pc, r0]
  259974: e5900000     	ldr	r0, [r0]
  259978: e59f1000     	ldr	r1, [pc]                @ 0x259980 <start+0x24ceb4>
  25997c: ea000000     	b	0x259984 <start+0x24ceb8> @ imm = #0x0
  259980: 004f7588     	subeq	r7, pc, r8, lsl #11
  259984: e79f1001     	ldr	r1, [pc, r1]
  259988: e5911000     	ldr	r1, [r1]
  25998c: e1500001     	cmp	r0, r1
  259990: 13a00000     	movne	r0, #0
  259994: 03a00001     	moveq	r0, #1
  259998: e3500000     	cmp	r0, #0
  25999c: 0a000004     	beq	0x2599b4 <start+0x24cee8> @ imm = #0x10
  2599a0: e59f0000     	ldr	r0, [pc]                @ 0x2599a8 <start+0x24cedc>
  2599a4: ea000000     	b	0x2599ac <start+0x24cee0> @ imm = #0x0
  2599a8: 004f7558     	subeq	r7, pc, r8, asr r5
  2599ac: e79f0000     	ldr	r0, [pc, r0]
  2599b0: e590a000     	ldr	r10, [r0]
  2599b4: e58ba000     	str	r10, [r11]
  2599b8: e1a0000a     	mov	r0, r10
  2599bc: e28bd00c     	add	sp, r11, #12
  2599c0: e8bd0d00     	pop	{r8, r10, r11}
  2599c4: e59d7008     	ldr	r7, [sp, #0x8]
  2599c8: e89da000     	ldm	sp, {sp, pc}
