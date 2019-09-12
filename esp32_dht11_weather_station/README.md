# ESP32 Weather Station, DHT11, SSD1306

## YouTube

[![ESP32 Weather Station, DHT11, SSD1306](https://img.youtube.com/vi/kZOR3DmBcmE/hqdefault.jpg)](https://www.youtube.com/watch?v=kZOR3DmBcmE)

## Pinout

| DHT11 | NodeMCU - ESP32 |
| --- | --- |
| GND | GND |
| VCC | VN |
| DATA | 25 |

| SSD1306 | NodeMCU - ESP32 |
| --- | --- |
| GND | GND |
| VCC | 3V3 |
| SCL | 27 |
| SDL | 26 |

## Code

```lua
id = i2c.HW0
sda = 26
scl = 27
sla = 0x3c
i2c.setup(id, sda, scl, i2c.FAST)
disp = u8g2.ssd1306_i2c_128x64_noname(id, sla)

disp:setFont(u8g2.font_6x10_tf)
disp:setFontRefHeightExtendedText()
disp:setDrawColor(1)
disp:setFontPosTop()
disp:setFontDirection(0)

disp:clearBuffer()

local timer = tmr.create()

timer:register(1000, tmr.ALARM_AUTO, function()
    local status, temp, humi = dht.read11(25)

    disp:clearBuffer()
    
    if status == dht.OK then
        disp:drawStr(0,  0, "Temperature: " .. temp .. "°C")
        disp:drawStr(0, 10, "   Humidity: " .. humi .. "%")
    else
        disp:drawStr(0, 0, "Error")
    end

    disp:sendBuffer()
end)

timer:start()
```
