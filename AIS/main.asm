.include "m16def.inc"
.def temp=r16
.def count=r17
rjmp init
;
init:
ldi temp,$80
out SPL,temp
ldi count,5
m1:
inc r18
inc r19
add r18,r19
mov r20,r18
push r20
pop r21
subi r20,2
dec count
brne m1
ret
