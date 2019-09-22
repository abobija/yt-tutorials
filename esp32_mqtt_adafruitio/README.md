# ESP32 MQTT, adafruit.io, Lua

## YouTube

[![ESP32 MQTT, adafruit.io, Lua](https://img.youtube.com/vi/3p7RSyHbmS4/hqdefault.jpg)](https://www.youtube.com/watch?v=3p7RSyHbmS4)

## Code

```lua
local username = 'AIO_USERNAME'
local aioKey = 'AIO_KEY'

local BLUE_LED = 2

gpio.config({ gpio = BLUE_LED, dir = gpio.IN_OUT })
gpio.write(BLUE_LED, 0)

local client = mqtt.Client('clientx', 120, username, aioKey)

client:on('connect', function() print('connected') end)
client:on('offline', function() print('offline') end)

client:on('message', function(_, topic, data)
    print(topic, ':', data)

    if topic == username .. '/f/home.led' then
        if data == 'ON' then
            gpio.write(BLUE_LED, 1)
        elseif data == 'OFF' then
            gpio.write(BLUE_LED, 0)
        end
    end
end)

function connect()
    client:connect('io.adafruit.com', 1883, 0, function()
        print('connected')

        client:subscribe(username .. '/f/home.led', 0, function()
            print('subscribe success')
        end)
    end,
    function(_, reason)
        print('failed', reason)
    end)
end

wifi.mode(wifi.STATION)

wifi.sta.config({
    ssid  = 'Renault 1.9D',
    pwd   = 'renault19',
    auto  = false
})

wifi.sta.on('got_ip', connect)

wifi.start()
wifi.sta.connect()
```