from rcon.source import Client
from rcon.source.proto import Packet
src=bytes(Packet.make_login("MyPassword"))
print(src.hex('-'))
# with Client("43.248.191.107",10011,passwd="MyPassword") as client:
#     print(client.run("ListCommands 1"))