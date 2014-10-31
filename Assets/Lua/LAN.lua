require("core.unity3d")
require("core.loader")
json=require("lib/json")
print(" ---------------LAN main ---------------------")

LAN=luanet.LAN.instance


LAN:StartServer()