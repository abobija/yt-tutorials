# ESP-IDF Setup Under Ubuntu VM + Using VS Code as a Code Editor

## YouTube

[![ESP-IDF Setup Under Ubuntu VM + Using VS Code as a Code Editor](https://img.youtube.com/vi/XIYsYoGWodw/hqdefault.jpg)](https://youtu.be/XIYsYoGWodw)

## Setup Toolchain

To compile with ESP-IDF you need to get the following packages by executing next apt-get command

```
sudo apt-get install git wget flex bison gperf python python-pip python-setuptools python-serial python-click python-cryptography python-future python-pyparsing python-pyelftools cmake ninja-build ccache
```

Add your user to dialout group with next command

```
sudo usermod -a -G dialout $USER
```

Go to home folder

```
cd ~
```

Make new folder with name `esp`

```
mkdir esp
cd esp
```

Clone ESP-IDF repository

```
git clone --recursive https://github.com/espressif/esp-idf.git
```

Go inside of ESP-IDF folder

```
cd ~/esp/esp-idf
```

Once when installation shell script dowload all necessary tools we need to setup correct environment variables. ESP-IDF provides another script which does that. So execute next command and notice that we have one empty space beetwen two dots.

```
. ./export.sh
```

To automate this step, making ESP-IDF tools available in every terminal, we are need to add this line to `~/.profile` script

```
$HOME/esp/esp-idf/export.sh
```

## VS Code installation

Update the packages index and install dependencies by typing next command

```
sudo apt update
sudo apt install software-properties-common apt-transport-https wget
```

Import Microsoft GPG key using following wget command

```
wget -q https://packages.microsoft.com/keys/microsoft.asc -O- | sudo apt-key add -
```

With next command Enable VS Code repository

```
sudo add-apt-repository "deb [arch=amd64] https://packages.microsoft.com/repos/vscode stable main"
```

Once when apt repository is enabled, install the latest version of Visual Studio Code

```
sudo apt update
sudo apt install code
```

## VS Code C/C++ Configuration

When you open your project with VSCode create new folder `.vscode` inside of your project root folder.

Inside of `.vscode` folder create `c_cpp_properties.json` file with next content:

```json
{
    "configurations": [
        {
            "name": "Linux",
            "includePath": [
                "${workspaceFolder}/**",
                "${workspaceFolder}/build",
                "${env:IDF_PATH}/components/**"
            ],
            "defines": [],
            "compilerPath": "/usr/bin/gcc",
            "cStandard": "c11",
            "cppStandard": "c++17",
            "intelliSenseMode": "clang-x64"
        }
    ],
    "version": 4
}
```

That's it.

_Best regards_<br>
_Alija Bobija_