# Solving [Bandit@overthewire.org](https://overthewire.org/wargames/bandit/)

## [Bandit Level 0 → Level 1](https://overthewire.org/wargames/bandit/bandit1.html)

```bash
ssh bandit0@bandit.labs.overthewire.org -p 2220
password: bandit0
```

Code to answer:

```bash
$ ls
readme

$ cat readme
NH2SXQwcBdpmTEzi3bvBHMM9H66vVXjL
```

## [Bandit Level 1 → Level 2](https://overthewire.org/wargames/bandit/bandit2.html)

```bash
ssh bandit1@bandit.labs.overthewire.org -p 2220
password: NH2SXQwcBdpmTEzi3bvBHMM9H66vVXjL
```

Code to answer:

```bash
$ ls
-

$ cat ./-
rRGizSaX8Mk1RTb1CNQoXTcYZWU6lgzi
```

## [Bandit Level 2 → Level 3](https://overthewire.org/wargames/bandit/bandit3.html)

```bash
ssh bandit2@bandit.labs.overthewire.org -p 2220
password: rRGizSaX8Mk1RTb1CNQoXTcYZWU6lgzi
```

Code to answer:

```bash
$ ls
spaces in this filename

$ cat spaces\ in\ this\ filename
aBZ0W5EmUfAf7kHTQeOwd8bauFJ2lAiG
```

## [Bandit Level 3 → Level 4](https://overthewire.org/wargames/bandit/bandit4.html)

```bash
ssh bandit3@bandit.labs.overthewire.org -p 2220
password: aBZ0W5EmUfAf7kHTQeOwd8bauFJ2lAiG
```

Code to answer:

```bash
~$ ls
inhere

~$ cd inhere/

~/inhere$ ls

~/inhere$ ls -la
total 12
drwxr-xr-x 2 root    root    4096 Sep  1 06:30 .
drwxr-xr-x 3 root    root    4096 Sep  1 06:30 ..
-rw-r----- 1 bandit4 bandit3   33 Sep  1 06:30 .hidden

~/inhere$ cat .hidden
2EW7BBsr6aMMoJ2HjW067dm8EgX26xNe
```

## [Bandit Level 4 → Level 5](https://overthewire.org/wargames/bandit/bandit5.html)

```bash
ssh bandit4@bandit.labs.overthewire.org -p 2220
password: 2EW7BBsr6aMMoJ2HjW067dm8EgX26xNe
```

> **Hint:** The password for the next level is stored in the only human-readable file in the inhere directory. Tip: if your terminal is messed up, try the “reset” command.

Code to answer:

```bash
~$ file ./inhere/*
./inhere/-file00: OpenPGP Public Key
./inhere/-file01: data
./inhere/-file02: data
./inhere/-file03: data
./inhere/-file04: data
./inhere/-file05: data
./inhere/-file06: data
./inhere/-file07: ASCII text
./inhere/-file08: data
./inhere/-file09: data

~$ cat ./inhere/-file07
lrIWWI6bB37kxfiCQZqUdOIYfr6eEeqR
```

> **Key-Takeaway:** Use the `file` command to display the type of the passed

## [Bandit Level 5 → Level 6](https://overthewire.org/wargames/bandit/bandit6.html)

```bash
ssh bandit5@bandit.labs.overthewire.org -p 2220
password: lrIWWI6bB37kxfiCQZqUdOIYfr6eEeqR
```

> **Hint:** The password for the next level is stored in a file somewhere under the inhere directory and has all of the following properties:

```
human-readable
1033 bytes in size
not executable
```

Code to answer:

```bash
# In order to learn more about options
~$ man find | grep size
~$ man find | grep exe
~$ man find | grep readable

~/inhere$ find . -size 1033c -type f -readable | xargs cat | xargs
P4L4vucdmLnm8I7Vl7jG1ApGSfjYKqJU
```

> **Key-Takeaways:**
>
> * Use `find .` to get every file and folder under a given path.
> * Use `find . -type f` to look for only files.
> * Use `find . -readable` to look for only readable files.
> * Use `find . -size 1033c` to specify the bytes of the file.
> * Use `find . -executable` to look for executable files.
> * Use `!` before an option to complement it.
> * Pipe `xargs` to apply an operation to the output of the previous one. Concatenated removes the spaces of the final output.

## [Bandit Level 6 → Level 7](https://overthewire.org/wargames/bandit/bandit7.html)

```bash
ssh bandit6@bandit.labs.overthewire.org -p 2220
password: P4L4vucdmLnm8I7Vl7jG1ApGSfjYKqJU
```

> **Hint:** The password for the next level is stored somewhere on the server and has all of the following properties:

```
owned by user bandit7
owned by group bandit6
33 bytes in size
```

Code to answer:

```bash
# In order to learn more about options

~$ man find | grep user
~$ man find | grep group
~$ man find | grep readable

~$ find / -size 33c -user bandit7 -group bandit6 2>/dev/null | xargs cat
z7WtoNQU2XfjmMtWA8u5rN4vzqu4v99S
```

> **Key-Takeaways:**
>
> * Use `find . -user <USER_NAME>` to look for files owned by a user.
> * Use `find . -group <GROUP_NAME>` to look for files owned by a group.
> * Use `2>/dev/null` to redirect errors to dev null (kind of like a black hole).

## [Bandit Level 7 → Level 8](https://overthewire.org/wargames/bandit/bandit8.html)

```bash
ssh bandit7@bandit.labs.overthewire.org -p 2220
password: z7WtoNQU2XfjmMtWA8u5rN4vzqu4v99S
```

> **Hint:** The password for the next level is stored in the file **data.txt** next to the word **millionth**.

Code to answer:

```bash
~$ cat data.txt | grep millionth
TESKZC0XvTetK0S9xNwm25STk5iWrBvP
```

## [Bandit Level 8 → Level 9](https://overthewire.org/wargames/bandit/bandit9.html)

```bash
ssh bandit8@bandit.labs.overthewire.org -p 2220
password: TESKZC0XvTetK0S9xNwm25STk5iWrBvP
```

> **Hint:** The password for the next level is stored in the file **data.txt** and is the only line of text that occurs **only once**.

Code to answer:

```bash
~$ sort data.txt | uniq -u
EN632PlfYiZbn3PhVK3XOGSlNInNE00t
```

> **Key-Takeaway:** `uniq -u` takes care of adjacent duplicates, with the `-u` option, it outputs only unique lines

## [Bandit Level 9 → Level 10](https://overthewire.org/wargames/bandit/bandit10.html)

```bash
ssh bandit9@bandit.labs.overthewire.org -p 2220
password: EN632PlfYiZbn3PhVK3XOGSlNInNE00t
```

> **Hint:** The password for the next level is stored in the file **data.txt** in one of the few human-readable strings, preceded by several ‘=’ characters.

> **Possible commands:** `grep, sort, uniq, strings, base64, tr, tar, gzip, bzip2, xxd`

Code to answer:

```bash
~$ strings data.txt | grep ==
========== the
bu========== password
4iu========== is
b~==P
========== G7w8LIi6J3kTb8A7j9LgrywtEUlyyp6s
```

> **Key-Takeaway:** `strings` prints the printable character sequences that are at least 4 characters long (or the number given with the options below) and are followed by an unprintable character.

## [Bandit Level 10 → Level 11](https://overthewire.org/wargames/bandit/bandit11.html)

```bash
ssh bandit10@bandit.labs.overthewire.org -p 2220
password: G7w8LIi6J3kTb8A7j9LgrywtEUlyyp6s
```

> **Hint:** The password for the next level is stored in the file data.txt, which contains base64 encoded data.

> **Possible commands:** `grep, sort, uniq, strings, base64, tr, tar, gzip, bzip2, xxd`

Code to answer:

```bash
~$ base64 -d data.txt
The password is 6zPeziLdR2RKNdNYFNb6nVCKzphlXHBM
```

## [Bandit Level 11 → Level 12](https://overthewire.org/wargames/bandit/bandit12.html)

```bash
ssh bandit11@bandit.labs.overthewire.org -p 2220
password: 6zPeziLdR2RKNdNYFNb6nVCKzphlXHBM
```

> **Hint:** The password for the next level is stored in the file data.txt, where all lowercase (a-z) and uppercase (A-Z) letters have been rotated by 13 positions.

> **Possible commands:** `grep, sort, uniq, strings, base64, tr, tar, gzip, bzip2, xxd`

Code to answer:

```bash
~$ cat data.txt | tr '[A-Za-z]' '[N-ZA-Mn-za-m]'
The password is JVNBBFSmZwKKOP0XbFXOoW8chDz5yVRv
```

> **Key-Takeaways:**
> The `tr` command replaces characters according to a specific logic. In this example.
>
> * For upper case cases, we got 13 rotation using. "Map from A-Z to N-ZA-M"
> * For lower case cases, the same was performed by. "Map from a-z to n-za-m"

## [Bandit Level 12 → Level 13](https://overthewire.org/wargames/bandit/bandit13.html)

```bash
ssh bandit12@bandit.labs.overthewire.org -p 2220
password: JVNBBFSmZwKKOP0XbFXOoW8chDz5yVRv
```

> **Hint:** The password for the next level is stored in the file data.txt, which is a hexdump of a file that has been repeatedly compressed. For this level it may be useful to create a directory under /tmp in which you can work using mkdir. For example: mkdir /tmp/myname123. Then copy the datafile using cp, and rename it using mv (read the manpages!).

> **Possible commands:** `grep, sort, uniq, strings, base64, tr, tar, gzip, bzip2, xxd, mkdir, cp, mv, file`

Code to answer:

```bash
$ man xxd | grep hexdump
$ cd /tmp
$ mkdir my_test && cd my_test
$ cp ~/data.txt .

# 1st compressed file
$ man xxd | grep hexd
$ xxd -r data.txt > decompressed_data.txt
$ file decompressed_data.txt
'decompressed_data.txt: gzip compressed data, was "data2.bin", last modified: Thu Sep  1 06:30:09 2022, max compression, from Unix, original size modulo 2^32 575'

# 2nd compressed file
$ man gzip | grep decomp
$ cp decompressed_data.txt decompressed_data.gz
$ gzip -d decompressed_data.gz
$ file decompressed_data
'decompressed_data: bzip2 compressed data, block size = 900k'

# 3rd compressed file
$ man bzip2 | grep decomp
$ bzip2 -d decompressed_data
"bzip2: Can't guess original name for decompressed_data -- using decompressed_data.out"
$ file decompressed_data.out
'decompressed_data.out: gzip compressed data, was "data4.bin", last modified: Thu Sep  1 06:30:09 2022, max compression, from Unix, original size modulo 2^32 20480'

# 4th compressed file
$ mv decompressed_data.out decompressed_data.gz
$ gzip -d decompressed_data.gz
$ file decompressed_data
'decompressed_data: POSIX tar archive (GNU)'

# 5th compressed file
$ man tar | grep decomp
$ tar xvf decompressed_data
'data5.bin'
$ file data5.bin
'data5.bin: POSIX tar archive (GNU)'

# 6th compressed file
$ tar xvf data5.bin
'data6.bin'
$ file data6.bin
'data6.bin: POSIX tar archive (GNU)'

# 7th compressed file
$ tar xvf data6.bin
'data8.bin'
$ file data8.bin
$ mv data8.bin data8.gz
$ gzip -d data8.gz
$ file data8
$ cat data8
'The password is wbWdlBxEir4CaE8LaPhauuOo6pwRmrDw'
```

## [Bandit Level 13 → Level 14](https://overthewire.org/wargames/bandit/bandit14.html)

```bash
ssh bandit13@bandit.labs.overthewire.org -p 2220
password: 'wbWdlBxEir4CaE8LaPhauuOo6pwRmrDw'
```

> **Hint:** The password for the next level is stored in `/etc/bandit_pass/bandit14` and can only be read by user bandit14. For this level, you don’t get the next password, but you get a private SSH key that can be used to log into the next level.

> **Note:** localhost is a hostname that refers to the machine you are working on.

> **Possible commands:** `ssh, telnet, nc, openssl, s_client, nmap`

Code to answer:

```bash
cat sshkey.private
ssh --help
ssh bandit14@localhost -p 2220 -i sshkey.private
```

## [Bandit Level 14 → Level 15](https://overthewire.org/wargames/bandit/bandit15.html)

```bash
ssh bandit14@bandit.labs.overthewire.org -p 2220
password: 'fGrHPx402xGC7U7rXKDaxiWFTOiF0ENq'
```

> **Hint:** The password for the next level can be retrieved by submitting the password of the current level to port 30000 on localhost.

> **Possible commands:** `ssh, telnet, nc, openssl, s_client, nmap`

Code to answer:

```bash
$ cat /etc/bandit_pass/bandit14
'fGrHPx402xGC7U7rXKDaxiWFTOiF0ENq'
$ man nc localhost  30000 < fGrHPx402xGC7U7rXKDaxiWFTOiF0ENq
$ cat /etc/bandit_pass/bandit14 | nc localhost 30000
"Correct!"
"jN2kgmIXJ6fShzhT2avhotn4Zcka6tnt"
```

## [Bandit Level 15 → Level 16](https://overthewire.org/wargames/bandit/bandit16.html)

```bash
ssh bandit15@bandit.labs.overthewire.org -p 2220
password: 'jN2kgmIXJ6fShzhT2avhotn4Zcka6tnt'
```

> **Hint:** The password for the next level can be retrieved by submitting the password of the current level to port 30001 on localhost using SSL encryption.

> **Helpful note:** Getting “HEARTBEATING” and “Read R BLOCK”? Use -ign_eof and read the “CONNECTED COMMANDS” section in the manpage. Next to ‘R’ and ‘Q’, the ‘B’ command also works in this version of that command…

> **Possible commands:** `ssh, telnet, nc, openssl, s_client, nmap`

```bash

$ man telnet | grep ssl  # Doesn't give matches
$ man ssh | grep ssl  -C 5  # Doesn't give interesting matches
$ man nmap | grep ssl -C 5  # Doesn't give interesting matches
$ man openssl-s_client # That's it
$ openssl s_client -host localhost -port 30001
> ---
> read R BLOCK
jN2kgmIXJ6fShzhT2avhotn4Zcka6tnt
> Correct!
> JQttfApK4SeyHwDlI9SXGR50qclOAil1
```

## [Bandit Level 16 → Level 17](https://overthewire.org/wargames/bandit/bandit17.html)

```bash
ssh bandit16@bandit.labs.overthewire.org -p 2220
password: 'JQttfApK4SeyHwDlI9SXGR50qclOAil1'
```

> **Hint:** The credentials for the next level can be retrieved by submitting the password of the current level to a port on localhost in the range 31000 to 32000. First find out which of these ports have a server listening on them. Then find out which of those speak SSL and which don’t. There is only 1 server that will give the next credentials, the others will simply send back to you whatever you send to it.

> **Possible commands:** `ssh, telnet, nc, openssl, s_client, nmap`

Code to answer:

```bash
$ nmap localhost -p 31000-32000
"Starting Nmap 7.80 ( https://nmap.org ) at 2022-11-18 14:54 UTC
Nmap scan report for localhost (127.0.0.1)
Host is up (0.00013s latency).
Not shown: 996 closed ports
PORT      STATE SERVICE
31046/tcp open  unknown
31518/tcp open  unknown
31691/tcp open  unknown
31790/tcp open  unknown
31960/tcp open  unknown"

# After trying several ones...
$ openssl s_client -host localhost -port 31790
> ---
> read R BLOCK
JQttfApK4SeyHwDlI9SXGR50qclOAil1
> Correct!
"-----BEGIN RSA PRIVATE KEY-----
MIIEogIBAAKCAQEAvmOkuifmMg6HL2YPIOjon6iWfbp7c3jx34YkYWqUH57SUdyJ
imZzeyGC0gtZPGujUSxiJSWI/oTqexh+cAMTSMlOJf7+BrJObArnxd9Y7YT2bRPQ
Ja6Lzb558YW3FZl87ORiO+rW4LCDCNd2lUvLE/GL2GWyuKN0K5iCd5TbtJzEkQTu
DSt2mcNn4rhAL+JFr56o4T6z8WWAW18BR6yGrMq7Q/kALHYW3OekePQAzL0VUYbW
JGTi65CxbCnzc/w4+mqQyvmzpWtMAzJTzAzQxNbkR2MBGySxDLrjg0LWN6sK7wNX
x0YVztz/zbIkPjfkU1jHS+9EbVNj+D1XFOJuaQIDAQABAoIBABagpxpM1aoLWfvD
KHcj10nqcoBc4oE11aFYQwik7xfW+24pRNuDE6SFthOar69jp5RlLwD1NhPx3iBl
J9nOM8OJ0VToum43UOS8YxF8WwhXriYGnc1sskbwpXOUDc9uX4+UESzH22P29ovd
d8WErY0gPxun8pbJLmxkAtWNhpMvfe0050vk9TL5wqbu9AlbssgTcCXkMQnPw9nC
YNN6DDP2lbcBrvgT9YCNL6C+ZKufD52yOQ9qOkwFTEQpjtF4uNtJom+asvlpmS8A
vLY9r60wYSvmZhNqBUrj7lyCtXMIu1kkd4w7F77k+DjHoAXyxcUp1DGL51sOmama
+TOWWgECgYEA8JtPxP0GRJ+IQkX262jM3dEIkza8ky5moIwUqYdsx0NxHgRRhORT
8c8hAuRBb2G82so8vUHk/fur85OEfc9TncnCY2crpoqsghifKLxrLgtT+qDpfZnx
SatLdt8GfQ85yA7hnWWJ2MxF3NaeSDm75Lsm+tBbAiyc9P2jGRNtMSkCgYEAypHd
HCctNi/FwjulhttFx/rHYKhLidZDFYeiE/v45bN4yFm8x7R/b0iE7KaszX+Exdvt
SghaTdcG0Knyw1bpJVyusavPzpaJMjdJ6tcFhVAbAjm7enCIvGCSx+X3l5SiWg0A
R57hJglezIiVjv3aGwHwvlZvtszK6zV6oXFAu0ECgYAbjo46T4hyP5tJi93V5HDi
Ttiek7xRVxUl+iU7rWkGAXFpMLFteQEsRr7PJ/lemmEY5eTDAFMLy9FL2m9oQWCg
R8VdwSk8r9FGLS+9aKcV5PI/WEKlwgXinB3OhYimtiG2Cg5JCqIZFHxD6MjEGOiu
L8ktHMPvodBwNsSBULpG0QKBgBAplTfC1HOnWiMGOU3KPwYWt0O6CdTkmJOmL8Ni
blh9elyZ9FsGxsgtRBXRsqXuz7wtsQAgLHxbdLq/ZJQ7YfzOKU4ZxEnabvXnvWkU
YOdjHdSOoKvDQNWu6ucyLRAWFuISeXw9a/9p7ftpxm0TSgyvmfLF2MIAEwyzRqaM
77pBAoGAMmjmIJdjp+Ez8duyn3ieo36yrttF5NSsJLAbxFpdlc1gvtGCWW+9Cq0b
dxviW8+TFVEBl1O4f7HVm6EpTscdDxU+bCXWkfjuRb7Dy9GOtt9JPsX8MBTakzh3
vBgsyi/sN3RqRBcGU40fOoZyfAMT8s1m/uYv52O6IgeuZ/ujbjY=
-----END RSA PRIVATE KEY-----"
```

## [Bandit Level 17 → Level 18](https://overthewire.org/wargames/bandit/bandit18.html)

```bash
ssh bandit17@bandit.labs.overthewire.org -p 2220 -i lvl18.pem
```

> **Hint:** There are 2 files in the homedirectory: passwords.old and passwords.new. The password for the next level is in passwords.new and is the only line that has been changed between passwords.old and passwords.new

> **NOTE:** if you have solved this level and see ‘Byebye!’ when trying to log into bandit18, this is related to the next level, bandit19

> **Possible commands:** `cat, grep, ls, diff`

Code to answer:

```bash
$ diff passwords.old passwords.new
42c42
< 09wUIyMU4YhOzl1Lzxoz0voIBzZ2TUAf
---
> hga5tuuCLF6fFzUpnagiMN8ssu9LFrdg
```

## [Bandit Level 18 → Level 19](https://overthewire.org/wargames/bandit/bandit19.html)

```bash
ssh bandit18@bandit.labs.overthewire.org -p 2220
password: 'hga5tuuCLF6fFzUpnagiMN8ssu9LFrdg'
```

> **Hint:** The password for the next level is stored in a file readme in the homedirectory. Unfortunately, someone has modified .bashrc to log you out when you log in with SSH.

> **Possible commands:** `ssh, ls, cat`

Code to answer:

```bash
ssh bandit18@bandit.labs.overthewire.org -p 2220 bash
$ ls
$ cat readme
> awhqfNnAbc1naukrpqDYcF95h7HoMTrC
```

## [Bandit Level 19 → Level 20](https://overthewire.org/wargames/bandit/bandit20.html)

```bash
ssh bandit19@bandit.labs.overthewire.org -p 2220
password: 'awhqfNnAbc1naukrpqDYcF95h7HoMTrC'
```

> **Hint:** To gain access to the next level, you should use the setuid binary in the homedirectory. Execute it without arguments to find out how to use it. The password for this level can be found in the usual place (/etc/bandit_pass), after you have used the setuid binary.

Code to answer:

```bash
$ ./bandit20-do
$ ./bandit20-do cat /etc/bandit_pass/bandit20
> VxCazJaVykI6W36BkBU0mJTCM8rR95XT
```

## [Bandit Level 20 → Level 21](https://overthewire.org/wargames/bandit/bandit21.html)

```bash
ssh bandit20@bandit.labs.overthewire.org -p 2220
password: 'VxCazJaVykI6W36BkBU0mJTCM8rR95XT'
```

> **Hint:** There is a setuid binary in the homedirectory that does the following: it makes a connection to localhost on the port you specify as a commandline argument. It then reads a line of text from the connection and compares it to the password in the previous level (bandit20). If the password is correct, it will transmit the password for the next level (bandit21).

> **NOTE:** Try connecting to your own network daemon to see if it works as you think.

> **Possible commands:** `ssh, nc, cat, bash, screen, tmux, Unix ‘job control’ (bg, fg, jobs, &, CTRL-Z, …)`

Code to answer:

```bash
$ ./suconnect
"Usage: ./suconnect <portnumber>
This program will connect to the given port on localhost using TCP. If it receives the correct password from the other side, the next password is transmitted back."

$ screen
$ C-a |
$ C-a tab
$ C-a c
$ nc -l 1234
$ C-a tab
$ ./suconnect 1234
(paste password: VxCazJaVykI6W36BkBU0mJTCM8rR95XT)
NvEJF7oVjkddltPSrdKEFOllh9V1IBcq
```

> **Key-Takeaways:**
>
> The `screen` utility is  a full-screen window manager that multiplexes a physical terminal between several processes (typically interactive shells). It is very useful for dealing with multiple windows. Pressing `C-a` (in windows ctrl+A) and later a command, one can:
>
> * `C-a c`: Open and enter a new window.
> * `C-a digit`: Switch to window number 0-9.
> * `C-a C-a`: Get back to previous window.
> * `C-a |`: Split the current region vertically into two new vertical regions.
> * `C-a tab`: Switch the input focus to the next region.

## [Bandit Level 21 → Level 22](https://overthewire.org/wargames/bandit/bandit22.html)

```bash
ssh bandit21@bandit.labs.overthewire.org -p 2220
password: 'NvEJF7oVjkddltPSrdKEFOllh9V1IBcq'
```

> **Hint:** A program is running automatically at regular intervals from cron, the time-based job scheduler. Look in /etc/cron.d/ for the configuration and see what command is being executed.

> **Possible commands:** `cron, crontab, crontab(5)` (use “man 5 crontab” to access this)

Code to answer:

```bash
$ man cron
$ ls /etc/cron.d/
$ cat cronjob_bandit22
@reboot bandit22 /usr/bin/cronjob_bandit22.sh &> /dev/null
* * * * * bandit22 /usr/bin/cronjob_bandit22.sh &> /dev/null
$ cat /tmp/t7O6lds9S0RqQh9aMcz6ShpAoZKF7fgv
WdDozAdTM2z9DiFEQ2mGlwngMfj4EZff
```

> **Key-Takeaways:** In cron `* * * * *` means every minute of every day of every week of every month.

## [Bandit Level 22 → Level 23](https://overthewire.org/wargames/bandit/bandit23.html)

```bash
ssh bandit22@bandit.labs.overthewire.org -p 2220
password: 'WdDozAdTM2z9DiFEQ2mGlwngMfj4EZff'
```

> **Hint:** A program is running automatically at regular intervals from cron, the time-based job scheduler. Look in /etc/cron.d/ for the configuration and see what command is being executed.
>
> **NOTE:** Looking at shell scripts written by other people is a very useful skill. The script for this level is intentionally made easy to read. If you are having problems understanding what it does, try executing it to see the debug information it prints.

Code to answer:

```bash
$ cd /etc/cron.d/
$ cat cronjob_bandit23
'@reboot bandit23 /usr/bin/cronjob_bandit23.sh  &> /dev/null
* * * * * bandit23 /usr/bin/cronjob_bandit23.sh  &> /dev/null'
$ cat /usr/bin/cronjob_bandit23.sh
'#!/bin/bash
myname=$(whoami)
mytarget=$(echo I am user $myname | md5sum | cut -d ' ' -f 1)
echo "Copying passwordfile /etc/bandit_pass/$myname to /tmp/$mytarget"
cat /etc/bandit_pass/$myname > /tmp/$mytarget'
$ echo I am user bandit22 | md5sum | cut -d ' ' -f 1
8169b67bd894ddbb4412f91573b38db3
$ cat /tmp/8ca319486bfbbc3663ea0fbe81326349
QYw0Y2aiA672PsMmh9puTQuhoz8SyR2G
```

## [Bandit Level 23 → Level 24](https://overthewire.org/wargames/bandit/bandit24.html)

```bash
ssh bandit23@bandit.labs.overthewire.org -p 2220
password: 'QYw0Y2aiA672PsMmh9puTQuhoz8SyR2G'
```

> **Hint:** A program is running automatically at regular intervals from cron, the time-based job scheduler. Look in /etc/cron.d/ for the configuration and see what command is being executed.
>
>**NOTE:** This level requires you to create your own first shell-script. This is a very big step and you should be proud of yourself when you beat this level!
>
>**NOTE 2:** Keep in mind that your shell script is removed once executed, so you may want to keep a copy around…

Code to answer:

```bash
$ cd /etc/cron.d/
$ cat cronjob_bandit24
'@reboot bandit24 /usr/bin/cronjob_bandit24.sh &> /dev/null
* * * * * bandit24 /usr/bin/cronjob_bandit24.sh &> /dev/null'
$ cat /usr/bin/cronjob_bandit24.sh
'#!/bin/bash

myname=$(whoami)
cd /var/spool/$myname/foo
echo "Executing and deleting all scripts in /var/spool/$myname/foo:"
for i in * .*;
do
    if [ "$i" != "." -a "$i" != ".." ];
    then
        echo "Handling $i"
        owner="$(stat --format "%U" ./$i)"
        if [ "${owner}" = "bandit23" ]; then
            timeout -s 9 60 ./$i
        fi
        rm -f ./$i
    fi
done'


$ touch /tmp/my_pass
$ chmod 777 /tmp/my_pass
$ cd /var/spool/bandit24/foo
$ vim my_script.sh
```

Put the folowing content:

```bash
#!/bin/bash
cat /etc/bandit_pass/bandit24 > /tmp/my_pass
```

Make it executable for bandit24 (the user running the script).

```bash
chmod 777 /var/spool/bandit24/foo/my_script.sh
```

After a minute...

```bash
$ cat /tmp/my_pass
VAfGXJ1PBSsPSnvsjI8p759leLZ9GGar
```

## [Bandit Level 24 → Level 25](https://overthewire.org/wargames/bandit/bandit25.html)

```bash
ssh bandit24@bandit.labs.overthewire.org -p 2220
password: 'VAfGXJ1PBSsPSnvsjI8p759leLZ9GGar'
```

> **Hint:** A daemon is listening on port 30002 and will give you the password for bandit25 if given the password for bandit24 and a secret numeric 4-digit pincode. There is no way to retrieve the pincode except by going through all of the 10000 combinations, called brute-forcing.

Code to answer:

```bash
$ nc localhost 30002
'I am the pincode checker for user bandit25. Please enter the password for user bandit24 and the secret pincode on a single line, separated by a space.'
test test
'Wrong! Please enter the correct current password. Try again.'
test
'Fail! You did not supply enough data. Try again.'
$ echo VAfGXJ1PBSsPSnvsjI8p759leLZ9GGar 0000 | nc localhost 30002
'I am the pincode checker for user bandit25. Please enter the password for user bandit24 and the secret pincode on a single line, separated by a space.
Wrong! Please enter the correct pincode. Try again.'
$ cd /tmp
$ vim my_script.sh
$ for i in {0001..9999}; do; echo VAfGXJ1PBSsPSnvsjI8p759leLZ9GGar $i; done | nc localhost 30002 > log.txt
$ uniq log.txt
'I am the pincode checker for user bandit25. Please enter the password for user bandit24 and the secret pincode on a single line, separated by a space.
Wrong! Please enter the correct pincode. Try again.
Correct!
The password of user bandit25 is p7TaowMYrmu23Ol8hiZh9UvD0O9hpx8d'
```

## [Bandit Level 25 → Level 26](https://overthewire.org/wargames/bandit/bandit26.html)

```bash
ssh bandit25@bandit.labs.overthewire.org -p 2220
password: 'p7TaowMYrmu23Ol8hiZh9UvD0O9hpx8d'
```

> **Hint:** Logging in to bandit26 from bandit25 should be fairly easy… The shell for user bandit26 is not /bin/bash, but something else. Find out what it is, how it works and how to break out of it.

> **Possible commands:** `ssh, cat, more, vi, ls, id, pwd`

Code to answer:

```bash
$ ssh bandit26@bandit.labs.overthewire.org -p 2220 -i bandit26.sshkey
"...
  _                     _ _ _   ___   __
 | |                   | (_) | |__ \ / /
 | |__   __ _ _ __   __| |_| |_   ) / /_
 | '_ \ / _` | '_ \ / _` | | __| / / '_ \
 | |_) | (_| | | | | (_| | | |_ / /| (_) |
 |_.__/ \__,_|_| |_|\__,_|_|\__|____\___/
Connection to bandit.labs.overthewire.org closed."
```

```bash
$ cat /etc/passwd | grep bandit26
bandit26:x:11026:11026:bandit level 26:/home/bandit26:/usr/bin/showtext
```

This reads as:

* **Username:** `bandit26`.
* **Password:** An `x` character indicates that encrypted password is stored in /etc/shadow file.
* **User ID (UID):** `11026`. UID 0 (zero) is reserved for root and UIDs 1-99 are reserved for other predefined accounts. Further UID 100-999 are reserved by system for administrative and system accounts/groups.
* **Group ID (GID):** `11026` (The primary group ID stored in /etc/group file).
* **User ID Info (GECOS):** User comment `bandit level 26`.
* **Home directory:** `/home/bandit26`
* **Command/shell:** `/usr/bin/showtext`

```bash
$ cat /usr/bin/showtext
'#!/bin/sh

export TERM=linux

exec more ~/text.txt
exit 0'
```

`#!/bin/sh` means that we are using the **Bourne shell**. The solution consists on getting the terminal window small enough so `more` has to paginate the output of what is inside the text file. Then, press `v`, `:` and put the command `e /etc/bandit_pass/bandit26`

```bash
'c7GvcKlw9mC7aUQaPx7nwFstuAIBw1o1'
```

For getting into the bash.

```bash
:set shell=/bin/bash
:shell
```

> **Key-Takeaway:** The text file `passwd` at `/etc` stores user account information required during login. It contains a list of the system’s accounts, giving for each account some useful information like user ID, group ID, home directory, shell, and more.

## [Bandit Level 26 → Level 27](https://overthewire.org/wargames/bandit/bandit27.html)

```bash
ssh bandit26@bandit.labs.overthewire.org -p 2220
password: 'c7GvcKlw9mC7aUQaPx7nwFstuAIBw1o1'
```

> **Hint:** Good job getting a shell! Now hurry and grab the password for bandit27!

The solution consists on getting the terminal window small enough so `more` has to paginate the output of what is inside the text file. Then, press `v` and put the following

```bash
:set shell=/bin/bash
:shell
```

```bash
$ ./bandit27-do cat /etc/bandit_pass/bandit27
'YnQpBuifNMas1hcUFk70ZmqkhUU2EuaS'
```

## [Bandit Level 27 → Level 28](https://overthewire.org/wargames/bandit/bandit28.html)

```bash
ssh bandit27@bandit.labs.overthewire.org -p 2220
password: 'YnQpBuifNMas1hcUFk70ZmqkhUU2EuaS'
```

> **Hint:** There is a git repository at `ssh://bandit27-git@localhost/home/bandit27-git/repo`.  The password for the user bandit27-git is the same as for the user bandit27. Clone the repository and find the password for the next level.

> **Possible commands:** `git`

Code to answer:

```bash
$ cd /tmp
$ mktemp -d
/tmp/tmp.j6pVgG0iEt
$ cd /tmp/tmp.j6pVgG0iEt
$ git clone ssh://bandit27-git@localhost:2220/home/bandit27-git/repo
$ cd repo
$ cat README
The password to the next level is: AVanL161y9rsbcJIsFHuw35rjaOM19nR
```

## [Bandit Level 28 → Level 29](https://overthewire.org/wargames/bandit/bandit29.html)

```bash
ssh bandit28@bandit.labs.overthewire.org -p 2220
password: 'AVanL161y9rsbcJIsFHuw35rjaOM19nR'
```

> **Hint:** There is a git repository at ssh://bandit28-git@localhost/home/bandit28-git/repo. The password for the user bandit28-git is the same as for the user bandit28.

> **Possible commands:** `git`

Code to answer:

```bash
$ cd /tmp
$ mktemp -d
/tmp/tmp.j6pVgG0iEt
$ cd /tmp/tmp.j6pVgG0iEt
$ git clone ssh://bandit28-git@localhost:2220/home/bandit28-git/repo
$ cd repo
$ cat README.md
"
# Bandit Notes
Some notes for level29 of bandit.

## credentials

- username: bandit29
- password: xxxxxxxxxx
"
$ git log
"
commit 43032edb2fb868dea2ceda9cb3882b2c336c09ec (HEAD -> master, origin/master, origin/HEAD)
Author: Morla Porla <morla@overthewire.org>
Date:   Thu Sep 1 06:30:25 2022 +0000

    fix info leak

commit bdf3099fb1fb05faa29e80ea79d9db1e29d6c9b9
Author: Morla Porla <morla@overthewire.org>
Date:   Thu Sep 1 06:30:25 2022 +0000

    add missing data

commit 43d032b360b700e881e490fbbd2eee9eccd7919e
Author: Ben Dover <noone@overthewire.org>
Date:   Thu Sep 1 06:30:24 2022 +0000

    initial commit of README.md
"
$ git checkout bdf3099fb1fb05faa29e80ea79d9db1e29d6c9b9
$ cat README.md
"
# Bandit Notes
Some notes for level29 of bandit.

## credentials

- username: bandit29
- password: tQKvmcwNYcFS6vmPHIUSI3ShmsrQZK8S
"
```

## [Bandit Level 29 → Level 0](https://overthewire.org/wargames/bandit/bandit30.html)

```bash
ssh bandit29@bandit.labs.overthewire.org -p 2220
password: 'tQKvmcwNYcFS6vmPHIUSI3ShmsrQZK8S'
```

> **Hint:** There is a setuid binary in the homedirectory that does the following: it makes a connection to localhost on the port you specify as a commandline argument. It then reads a line of text from the connection and compares it to the password in the previous level (bandit20). If the password is correct, it will transmit the password for the next level (bandit21).

> **NOTE:** Try connecting to your own network daemon to see if it works as you think

> **Possible commands:** `ssh, nc, cat, bash, screen, tmux, Unix ‘job control’ (bg, fg, jobs, &, CTRL-Z, …)`

Code to answer:

```bash
```

___

## [Bandit Level 20 → Level 21](https://overthewire.org/wargames/bandit/bandit21.html)

```bash
ssh bandit20@bandit.labs.overthewire.org -p 2220
password: ''
```

> **Hint:**

> **Possible commands:** ``

Code to answer:

```bash
```
