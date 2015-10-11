#include <stdio.h>
#include <string.h>
#include <conio.h>
#include <iostream>
#include <tchar.h>
using namespace std;

int main()
{
    string s = "Поменьше говори - больше услышишь";
    int length_leter = 0;
    char leters[20]={0};
    int freq[20]={0};
    for(int i=0; i<strlen(s); i++)
    {
        int flag = 0;
        for(int j=0; j<length_leter); j++)
            if(s[i] == leters[j])
            {
                freq[j]++;
                flag = 1;
                break;
            }
        if(flag == 0)
        {
            leters[length_leter]=s[i];
            freq[length_leter] = 1;
            length_leter++;
        }
    }
    for(int i=0; i<length_leter; i++)
    {
        printf("%c %d/n",leters[i],freq[i]);
    }

    return 0;
}
