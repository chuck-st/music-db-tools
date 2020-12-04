import json

f = open('json/songs.json', 'r')
json_str = f.read()
f.close()

songs = json.loads(json_str)

albums = [dict(album=x['album'], artist=x['artist']) for x in songs]
unique_albums = []
for x in albums:
    if x not in unique_albums:
        unique_albums.append(x)

hold = json.dumps(unique_albums)
f = open("json/albums-artists.json", "w")
f.write(hold)
f.close()
True
