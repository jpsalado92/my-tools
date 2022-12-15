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

### Solution

Visit source code of the webpage and look for the password there.

## [Level 1](http://natas1.natas.labs.overthewire.org)

```
Username: natas1
Password: g9D9cREhslqBKtcA2uocGHPfMZVzeFK6
```

### Solution

Same as before, but accessing web source code through, for example, f12.

## [Level 2](http://natas2.natas.labs.overthewire.org)

```
Username: natas2
Password: h4ubbcXrWqsTo7GGnnUMLppXbOogfBZ7
```

### Solution

1. Check source code of webpage.
2. Notice a suspicious pixel.png element.
3. Notice that there is an accessible `file` directory open in which the pixel file is located.
4. Get into http://natas2.natas.labs.overthewire.org/files/ and open the `user.txt` file in order to get access to the next level.

## [Level 3](http://natas3.natas.labs.overthewire.org)

```
Username: natas3
Password: G6ctbMJ5Nb4cbFwhpMPSvxGHhQ7I6W8Q
```

### Solution

The website appears empty.

After checking several URLs like `/files/` (as in the previous level) and `sitemap` , we find something at `http://natas3.natas.labs.overthewire.org/robots.txt` .

According to https://seocrawl.com/, Robots.txt is a special file known to SEOs (and programmers as well) which provides useful directives to search engine crawlers.

The content:

```
User-agent: *
Disallow: /s3cr3t/
```

The "Disallow" prevents search engines from accessing the `/s3cr3t/` directory, which is were the password for the next level is stored.

## [Level 4](http://natas4.natas.labs.overthewire.org)

```
Username: natas4
Password: tKOcJIbzM4lTs8hbCmzn5Zr4434fGZQm
```

### Solution

The password for the next level is retrieved if the page is visited from `http://natas5.natas.labs.overthewire.org` .

In order to trick the server, we can add a `Referer` header to the request with the value `http://natas5.natas.labs.overthewire.org` .

#referer-spoofing

### Key takeaways

* The `Referer` HTTP request header contains the absolute or partial address from which a resource has been requested. The Referer header allows a server to identify referring pages that people are visiting from or where requested resources are being used. This data can be used for analytics, logging, optimized caching, and more.

**Source**: https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Referer

## [Level 5](http://natas5.natas.labs.overthewire.org)

```
Username: natas5
Password: Z0NsrtIkJoKALBCLi5eqFfcRN82Au2oD
```

### Solution

Among the different headers for the request there is one that says `Cookie` , which is set to `0` . Guess what will happen if we include a header with the same header set to `1` ...

## [Level 6](http://natas6.natas.labs.overthewire.org)

```
Username: natas6
Password: fOIvE0MDtPTgRhqmmvvAOt2EfXR6uQgR
```

### Solution

Consulting "View sourcecode" link, we can notice the secret comes from `includes/secret.inc` . Getting into http://natas6.natas.labs.overthewire.org/includes/secret.inc we will find the password for the form, which will throw the password for the next level.

## [Level 7](http://natas7.natas.labs.overthewire.org)

```
Username: natas7
Password: jmxSiH3SP6Sonf8dv66ng8v1cIEdjXWr
```

### Solution

According to the links provided, there is an endpoint accepting the `page` parameter that will allow us to get into different resources. Passing a random value to this parameter like `test` throws:

```
Warning: include(test): failed to open stream: No such file or directory in /var/www/natas/natas7/index.php on line 21

Warning: include(): Failed opening 'test' for inclusion (include_path='.:/usr/share/php') in /var/www/natas/natas7/index.php on line 21
```

Also, the source code of the level itself says:

```
<!-- hint: password for webuser natas8 is in /etc/natas_webpass/natas8 -->
```

If we pass that path in the parameter, we get the password for the next level.

## [Level 8](http://natas8.natas.labs.overthewire.org)

```
Username: natas8
Password: a6bZCNYwdKqN5cGP11ZdtPg0iImQQhAB
```
