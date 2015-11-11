#include <stdio.h>
#include <string.h>
/*==============================
������������� ��������  LZ77
����� ������������������ �������
������� ���������� ������������,
                    ��� �������.
==============================*/
#define DICBITS   12             // Log
#define DICSIZE     // 4-32kB ������ �������
#define THRESHOLD 2              // �����
#define STRBITS   6              // Log
#define STRMAX   +THRESHOLD) // ���. ����� ������
#define BUFSIZE   0xff00U        // ������ ������ ������
#define TEXTSIZE  // ������ ������ ������
#define YES       1
#define NO        0

FILE *first_file, *second_file;
long srcleng=0, fileleng;
unsigned char *srcbuf, *srcstart;
/*==============================
========������� ������=========
==============================*/
int putbits()
{
        static int bitcounter=0;
        static int outdata=0;
        int bit, error;
        data<<=;
        for
        {
                if
                {
                        bitcounter=0;
                        error=putc;
                        if
                        {
                                printf;
                                return -5;
                        }
                }
        outdata<<=1;
        bit= ? 1:0;
        outdata+=bit;
        bitcounter++;
        data<<=1;
        }
}

/*==============================
======������� �������������=====
==============================*/
void compress_stud
{
//    struct stat buf;
        unsigned char  *position, *pointer; //���� � ����� , ���� � ������
        int i, dist, offset=0, last=NO, cnt, maxleng;

        printf;

        // ���������� ������ ��������� �����

        fstat,&buf);
        fileleng=buf.st_size;
        write, &fileleng, sizeof);

        // ������ ���� � ����� �� ������ ������� TEXTSIZE
        while)>0)
        {
                if // ��������� ����� ������
                {
                        last=YES;
                }
                position=srcstart;
                pointer=srcbuf;
                srcleng+=offset;
                while
                {
                        printf;
                        maxleng=0;

                        if && ) // ���� � ������ ������ �������� ���� ��������, �������� ������� � ���������� ����� � ������ ������ � ���������� ��������� ����� �� �����
                        {
                                memcpysrcleng);
                                offset=srcleng;
                                break;
                        }

                        for// ���� ����� ������� ����������� ������ � �������
                        {
                                for
                                if != * )
                                break;

                                if// ���� ����� ������ ������, �����������
                                continue;

                                if// ���� ������������ ������, ������ �� ����
                                {
                                        dist=DICSIZE-1-i; //�������
                                        maxleng=STRMAX; //�����
                                        break;
                                }

                                if // ���� ��������� ������ ������� ��� ���������, ��������� �� ����� � �������
                                {
                                        dist=DICSIZE-1-i; // �������
                                        maxleng=cnt; //�����
                                }
                        }

                        if &&  ) // ���������, ����� �� ���� ������ �� ������� �����
                        {
                                maxleng=srcleng; //�������� ����� �� ������� ������
                        }

                        if//���� ������ ���������� �������, ��������� pointer-���
                        {
                                printf;
                                putbits; //�������� ��� ������
                                putbits; //���������� �������
                                putbits; //���������� �����
                                position+=maxleng;
                                srcleng-=maxleng;
                                pointer+=maxleng;
                        }
                        else // ����� - chr-���
                        {
                                printf;
                                putbits;  //�������� ��� chr-���
                                putbits; //���������� ��� ���
                                position++;
                                srcleng--;
                                pointer++;
                        }
                }
        }

        // ���������� ���������� ����
        putbits;

        printf;
}

//���������������� ��������  LZ77

/*==============================
======������� ����������========
==============================*/
int getbits
{
        static int bitcounter=8;
        static int indata=0;
        int bit, data=0;

        for
        {
                if
                {
                        bitcounter=0;
                        indata=getc;
                }

                if
                {
                        printf;
                        return -6;
                }

                bit= ? 1:0;
                data<<=1;
                data+=bit;
                bitcounter++;
                indata<<=1;
        }
        return data;
}

/*==============================
=======������� ����������=======
==============================*/

void decompress_stud
{
        struct stat buf;
        unsigned char  *pos;
        int   i, dist, ch, maxleng;

        printf;

        // �������� ����� ��������� �����
        read,&fileleng,sizeof);
        pos=srcstart;

        while
                {
                if) == 0 ) // ���� chr-���, �������� � ����� ������ ������
                {
                        ch=getbits;
                        putc;
                        *pos=ch;
                        pos++;
                        fileleng--;
                }
                else // ����� - �������� maxleng �������� �� �������, ������� � ������� dist
                {
                        dist=getbits+1;
                        maxleng=getbits+THRESHOLD+1;
                        for
                        {
                                *=*;
                                putc,second_file);
                        }
                        pos+=maxleng;
                        fileleng-=maxleng;
                }

                if // ���� ����� ��������, ���������� ��� �� ���� � �������� ������� � ������ ������
                {
                        memcpy;
                        pos=srcstart;
                }
        }
        printf;
}
