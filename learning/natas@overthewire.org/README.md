# Solving [Natas@overthewire.org](https://overthewire.org/wargames/natas/)

## Intro
Natas teaches the basics of serverside web-security.

Each level of natas consists of its own website located at http://natasX.natas.labs.overthewire.org, where X is the level number. There is no SSH login. To access a level, enter the username for that level (e.g. natas0 for level 0) and its password.

Each level has access to the password of the next level. Your job is to somehow obtain that next password and level up. All passwords are also stored in /etc/natas_webpass/. E.g. the password for natas5 is stored in the file /etc/natas_webpass/natas5 and only readable by natas4 and natas5.


## [Level 0](http://natas0.natas.labs.overthewire.org)

```
Username: natas0
Password: natas0
```

**Solution:** Visit source code of the webpage and look for the password there.


## [Level 1](http://natas1.natas.labs.overthewire.org)

```
Username: natas1
Password: g9D9cREhslqBKtcA2uocGHPfMZVzeFK6
```

**Solution:** Same as before, but accessing web source code through, for example, f12.

## [Level 2](http://natas2.natas.labs.overthewire.org)

```
Username: natas2
Password: h4ubbcXrWqsTo7GGnnUMLppXbOogfBZ7
```

**Solution:**:
1. Check source code of webpage.
2. Notice a suspicious pixel.png element.
3. Notice that there is an accessible `file` directory open in which the pixel file is located.
4. Get into http://natas2.natas.labs.overthewire.org/files/ and open the `user.txt` file in order to get access to the next level.

## [Level 3](http://natas3.natas.labs.overthewire.org)

```
Username: natas2
Password: G6ctbMJ5Nb4cbFwhpMPSvxGHhQ7I6W8Q
```

**Solution:**:
