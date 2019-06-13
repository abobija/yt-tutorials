# Edison VS Tesla

## Demo

[![Edison VS Tesla](https://img.youtube.com/vi/4M5gUu0t64o/hqdefault.jpg)](https://www.youtube.com/watch?v=4M5gUu0t64o)

## Code

```lua
local piezo = require('piezo')({
    gpio = 13
})

local PIN_LIGHT_BULB = 14

gpio.config({ gpio = PIN_LIGHT_BULB, dir = gpio.IN_OUT })
gpio.write(PIN_LIGHT_BULB, 0)

local authorized_tags = {
    '0xBA 0x35 0x72 0xA9 0x54' -- Tesla's card
}

local is_authorized = function(hex)
    for _, sn in pairs(authorized_tags) do
        if sn == hex then
            return true
        end
    end

    return false
end

require('rfid32')({
    pin_sda  = 22,
    pin_clk  = 19,
    pin_miso = 25,
    pin_mosi = 23
})
.init()
.scan({
    got_tag = function(tag, rfid)
        if is_authorized(tag.hex()) then
            if gpio.read(PIN_LIGHT_BULB) == 0 then
                gpio.write(PIN_LIGHT_BULB, 1)
            else
                gpio.write(PIN_LIGHT_BULB, 0)
            end
        else
            piezo.error()
        end
    end
})
```