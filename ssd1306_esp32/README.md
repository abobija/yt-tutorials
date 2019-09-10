# Connect ESP32 with SSD1306 OLED Display using Lua, NodeMCU

## YouTube

[![Connect ESP32 with SSD1306 OLED Display using Lua, NodeMCU](https://img.youtube.com/vi/-wUoj2wqoe8/hqdefault.jpg)](https://www.youtube.com/watch?v=-wUoj2wqoe8)

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

disp:drawStr(0, 0, "Hello World")
disp:drawStr(0, 10, "Alija Bobija")

disp:sendBuffer()
```
