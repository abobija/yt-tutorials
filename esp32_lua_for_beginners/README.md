# Programming ESP32 in Lua

This repository is part of my YouTube video tutorial.
_*Click on image...*_

[![Programming ESP32 in Lua using ESPlorer IDE | For Beginners)](https://img.youtube.com/vi/ICRAlUCPpwY/hqdefault.jpg)](https://www.youtube.com/watch?v=ICRAlUCPpwY)

## Application written in the video

```lua
-- Print some welcome message
print('Hello from init.lua file!')

-- Blue LED is connected to pin #2
local BLUE_LED = 2

-- Configure BLUE_LED pin
gpio.config({ gpio = BLUE_LED, dir = gpio.IN_OUT })

-- Turn off LED on startup
gpio.write(BLUE_LED, 0)

-- Create a timer
local timer = tmr.create()

-- Register auto-repeating 1000 ms (1 sec) timer
timer:register(1000, tmr.ALARM_AUTO, function()
    -- Invert the state of BLUE_LED pin
    if gpio.read(BLUE_LED) == 1 then
        gpio.write(BLUE_LED, 0)
    else
        gpio.write(BLUE_LED, 1)
    end
end)

-- Start timer
timer:start()
```
