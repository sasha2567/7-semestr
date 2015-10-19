	.include "m16def.inc"
	
ldi r16,$D2
ldi r17,$2D
sts $0100,r16
sts $0101,r17
lds r16,$0100
lds r17,$0101
add r16,r17
add r16,r16
brcs 30
add r16,r16
brcs 30
add r16,r16
brcs 30
add r16,r16
brcs 30
add r16,r16
brcs 30
add r16,r16
brcs 30
add r16,r16
brcs 30

ldi r20, $55
ldi r21, $AA
out PortD, r20
out PortD, r21
ret
jmp qwq
qwq:
ldi r20, $FF
out PortB, r20
