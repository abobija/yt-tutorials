# ESP32 Build Environment
Instructions and dependencies required for setting-up ESP32 build environment

_This repository is part of my YouTube video tutorial._
_*Click on image...*_

[![ESP32 NodeMCU Lua - Config, build and flash | How to)](https://img.youtube.com/vi/_cK2Tac3Jz8/hqdefault.jpg)](https://www.youtube.com/watch?v=_cK2Tac3Jz8)

## Links

NodeMCU ESP32 docs:
https://nodemcu.readthedocs.io/en/dev-esp32/

Silicon Labs CP210x USB to UART Bridge VCP Drivers
https://www.silabs.com/products/development-tools/software/usb-to-uart-bridge-vcp-drivers

Python download:
https://www.python.org/downloads/

## Linux

Ubuntu Server 16.04.

### Commands
```
# PULL REPOSITORY

sudo git clone --branch dev-esp32 --recurse-submodules https://github.com/nodemcu/nodemcu-firmware.git nodemcu-firmware-esp32

cd nodemcu-firmware-esp32

# INSTALL DEPENDENCIES

sudo apt-get update

sudo apt-get install -y flex bison gperf python-pip libncurses5-dev libncursesw5-dev 

sudo pip install pyserial

/usr/bin/python -m pip install --user -r $HOME/nodemcu-firmware-esp32/sdk/esp32-esp-idf/requirements.txt

# CONFIGURATION

sudo make menuconfig

# BUILD

sudo make
```

### Generated Firmware paths

```
/nodemcu-firmware-esp32/build/NodeMCU.bin
/nodemcu-firmware-esp32/build/partitions_singleapp.bin
/nodemcu-firmware-esp32/build/bootloader/bootloader.bin
```

## Windows

Python needs to be installed before execution of next commands.

### Commands
```
# INSTALL ESPTOOL PYTHON SCRIPT

pip install esptool

# FLASH

esptool.py --chip esp32 --port COM7 --baud 115200 --before default_reset --after hard_reset write_flash -z --flash_mode dio --flash_freq 40m --flash_size detect 0x1000 bootloader.bin 0x10000 NodeMCU.bin 0x8000 partitions_singleapp.bin
```
