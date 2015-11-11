#include <stdio.h>
#include <string.h>
/*==============================
Архивирование Алгоритм  LZ77
Очень неоптимизированный вариант
Просьба обработать напильничком,
                    как следует.
==============================*/
#define DICBITS   12             // Log
#define DICSIZE     // 4-32kB Размер словаря
#define THRESHOLD 2              // Порог
#define STRBITS   6              // Log
#define STRMAX   +THRESHOLD) // Мах. длина строки
#define BUFSIZE   0xff00U        // Полный размер буфера
#define TEXTSIZE  // Размер буфера текста
#define YES       1
#define NO        0

FILE *first_file, *second_file;
long srcleng=0, fileleng;
unsigned char *srcbuf, *srcstart;
/*==============================
========Функция записи=========
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
======Функция Архивирования=====
==============================*/
void compress_stud
{
//    struct stat buf;
        unsigned char  *position, *pointer; //байт в файле , байт в буфере
        int i, dist, offset=0, last=NO, cnt, maxleng;

        printf;

        // Записываем размер исходного файла

        fstat,&buf);
        fileleng=buf.st_size;
        write, &fileleng, sizeof);

        // Читаем файл в буфер по частям размера TEXTSIZE
        while)>0)
        {
                if // Последняя часть текста
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

                        if && ) // Если в буфере текста осталось мало символов, сдвигаем словарь и оставшийся текст в начало буфера и дочитываем следующую часть из файла
                        {
                                memcpysrcleng);
                                offset=srcleng;
                                break;
                        }

                        for// Ищем самую длинную совпадающую строку в словаре
                        {
                                for
                                if != * )
                                break;

                                if// Если длина меньше порога, отбрасываем
                                continue;

                                if// Если максимальная строка, дальше не ищем
                                {
                                        dist=DICSIZE-1-i; //позиция
                                        maxleng=STRMAX; //длина
                                        break;
                                }

                                if // Если очередная строка длиннее уже найденных, сохраняеМ ее длину и позицию
                                {
                                        dist=DICSIZE-1-i; // позиция
                                        maxleng=cnt; //длина
                                }
                        }

                        if &&  ) // Проверяем, чтобы не было выхода за границы файла
                        {
                                maxleng=srcleng; //обрезаем длину по границу буфера
                        }

                        if//Если строка достаточно длинная, формируем pointer-код
                        {
                                printf;
                                putbits; //помечаем как ссылку
                                putbits; //записываем позицию
                                putbits; //записываем длину
                                position+=maxleng;
                                srcleng-=maxleng;
                                pointer+=maxleng;
                        }
                        else // Иначе - chr-код
                        {
                                printf;
                                putbits;  //помечаем как chr-код
                                putbits; //записываем чар код
                                position++;
                                srcleng--;
                                pointer++;
                        }
                }
        }

        // Записываем оставшиеся биты
        putbits;

        printf;
}

//Разархивирование Алгоритм  LZ77

/*==============================
======Функция считывания========
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
=======Функция Извлечения=======
==============================*/

void decompress_stud
{
        struct stat buf;
        unsigned char  *pos;
        int   i, dist, ch, maxleng;

        printf;

        // Получаем длину исходного файла
        read,&fileleng,sizeof);
        pos=srcstart;

        while
                {
                if) == 0 ) // Если chr-код, копируем в буфер текста символ
                {
                        ch=getbits;
                        putc;
                        *pos=ch;
                        pos++;
                        fileleng--;
                }
                else // Иначе - копируем maxleng символов из словаря, начиная с позиции dist
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

                if // Если буфер заполнен, записываем его на диск и сдвигаем словарь в начало буфера
                {
                        memcpy;
                        pos=srcstart;
                }
        }
        printf;
}
