
/Users/tomato/Documents/Codex/iQuarters/Recovery/native/iquarters-armv7:	file format mach-o arm

Disassembly of section __TEXT,__text:

0000cacc <start>:
  2411f0: e1a0c00d     	mov	r12, sp
  2411f4: e92d4080     	push	{r7, lr}
  2411f8: e1a0700d     	mov	r7, sp
  2411fc: e92d5900     	push	{r8, r11, r12, lr}
  241200: e24dd008     	sub	sp, sp, #8
  241204: e1a0b00d     	mov	r11, sp
  241208: e58b0000     	str	r0, [r11]
  24120c: e59f0000     	ldr	r0, [pc]                @ 0x241214 <start+0x234748>
  241210: ea000000     	b	0x241218 <start+0x23474c> @ imm = #0x0
  241214: 0050fb5c     	subseq	pc, r0, r12, asr r11
  241218: e79f0000     	ldr	r0, [pc, r0]
  24121c: eb014293     	bl	0x291c70 <start+0x2851a4> @ imm = #0x50a4c // System.Void UnityEngine.Application::LoadLevel(System.String)
  241220: e28bd008     	add	sp, r11, #8
  241224: e8bd0900     	pop	{r8, r11}
  241228: e59d7008     	ldr	r7, [sp, #0x8]
  24122c: e89da000     	ldm	sp, {sp, pc}
