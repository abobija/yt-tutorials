-- Title       : ESP32 WiFi LightBulb
-- Author      : Alija Bobija
-- Description : REST Service (api32) for controlling lightbulb state over the WiFi network
-- GitHub      : https://github.com/abobija/yt-tutorials/tree/master/esp32_light_bulb
-- Api32       : https://github.com/abobija/api32

local PIN_LIGHT_BULB = 14

gpio.config({ gpio = PIN_LIGHT_BULB, dir = gpio.IN_OUT })
gpio.write(PIN_LIGHT_BULB, 0)

local api = nil

local function lightbulb()
    return {
        Device = 'Light Bulb',
        State  = gpio.read(PIN_LIGHT_BULB)
    }
end

local function init_api32()
    if api == nil then
        api = require('api32')
            .create({
                auth = {
                    user = 'master',
                    pwd  = 'api32secret'
                }
            })
            .on_get('/lightbulb', lightbulb)
            .on_post('/lightbulb', function(jreq)
                if jreq ~= nil and jreq.State ~= nil then 
                    gpio.write(PIN_LIGHT_BULB, jreq.State)
                end
                
                return lightbulb()
            end)
    end
end

wifi.mode(wifi.STATION)

wifi.sta.config({
    ssid  = 'Renault 1.9D',
    pwd   = 'renault19',
    auto  = false
})

wifi.sta.on('got_ip', init_api32)

wifi.start()
wifi.sta.connect()
