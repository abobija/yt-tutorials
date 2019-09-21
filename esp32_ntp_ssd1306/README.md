# ESP32, Real Time Clock using NTP, SSD1306

## YouTube

[![ESP32, Real Time Clock using NTP, SSD1306](https://img.youtube.com/vi/u1vkhqi-N4c/hqdefault.jpg)](https://www.youtube.com/watch?v=u1vkhqi-N4c)

## Code

```lua
local id = i2c.HW0
local sda = 26
local scl = 27
local sla = 0x3c

i2c.setup(id, sda, scl, i2c.FAST)

local disp = u8g2.ssd1306_i2c_128x64_noname(id, sla)

disp:setFont(u8g2.font_6x10_tf)
disp:setFontRefHeightExtendedText()
disp:setDrawColor(1)
disp:setFontPosTop()
disp:setFontDirection(0)

disp:clearBuffer()

local function updateClock(_time)
    -- hh:mm:ss
    local timeStr = string.format('%02d:%02d:%02d', _time.hour, _time.min, _time.sec)

    -- DD.MM.YYYY
    local dateStr = string.format('%02d.%02d.%04d', _time.day, _time.mon, _time.year)

    local timeStrWidth = disp:getStrWidth(timeStr)
    local dateStrWidth = disp:getStrWidth(dateStr)

    disp:clearBuffer()

    disp:drawStr(128 / 2 - timeStrWidth / 2, 20, timeStr)
    disp:drawStr(128 / 2 - dateStrWidth / 2, 30, dateStr)

    disp:sendBuffer()
end

wifi.mode(wifi.STATION)

wifi.sta.config({
    ssid  = 'Renault 1.9D',
    pwd   = 'renault19',
    auto  = false
})

wifi.sta.on('got_ip', function()
    time.settimezone('UTC-2')
    time.initntp()

    local timer = tmr.create()

    timer:register(1000, tmr.ALARM_AUTO, function()
        updateClock(time.getlocal())
    end)

    timer:start()
end)

wifi.start()
wifi.sta.connect()
```
