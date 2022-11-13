# Windows personal setup

## 1. Install Windows Terminal 

https://apps.microsoft.com/store/detail/windows-terminal/9N0DX20HK701

## 2. Loosen execution policy

```bash
Set-ExecutionPolicy RemoteSigned
```
## 3. Get Chocolatey
```bash
# Get chocolatey install script and execute it
iwr -useb community.chocolatey.org/install.ps1 | iex

# Disable the behavior of double-checking if you want to install a package.
choco feature enable -n allowGlobalConfirmation
```

## 4. Install programs with chocolatey
```bash
choco upgrade [package-name]
choco upgrade all # keyword to try upgrade all packages
choco uninstall [package-name]


choco install vscode
choco install 7zip
choco install powershell-core
choco install sublimetext4

choco install qbittorrent --version 4.4.3.1 -y
choco install telegram --version 4.0.2 -y
choco install winrar --version 6.11.0.20220504 -y
choco install vlc --version 3.0.17.4 -y
choco install zoom --version 5.11.4.7185 -y
choco install github-desktop --version 3.0.5 -y
choco install whatsapp --version 2.2226.5 -y
choco install adobereader --version 2022.001.20169 -y
choco install googlechrome --version 103.0.5060.134 -y
choco install bulk-crap-uninstaller --version 5.3 -y
choco install git --version 2.37.1 -y
choco install 7zip --version 22.1 -y
choco install nodejs --version 18.7.0 -y
choco install vscode --version 1.69.2 -y
choco install docker-desktop --version 4.11.0 -y
# Social 
choco install discord --version 1.0.9005 -y


# Gets handy with dealing with PowerBI and Excel data models
choco install daxstudio 


```