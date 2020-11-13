from gmusicapi import Mobileclient
from gmusicapi.utils import utils
import json
import os
cwd = os.getcwd()
print(cwd)
# print(utils.log_filepath)
api = Mobileclient()
api.oauth_login("3d5cd50f3a136f32")
print(api.is_authenticated())
songs = api.get_all_songs()
playlists = api.get_all_user_playlist_contents()
with open('json/playlists.json', 'w') as outfile:
    json.dump(playlists, outfile)
with open('json/songs.json', 'w') as outfile:
    json.dump(songs, outfile)
