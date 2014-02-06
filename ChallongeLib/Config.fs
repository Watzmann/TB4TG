module Challonge.Lib.Config

open System.Configuration

let getkey (k:string) =  ConfigurationManager.AppSettings.Get(k)

let apikey = getkey "apikey"
let apiurlstem = getkey "apiurlstem"
let subdomain = getkey "subdomain"
let tg_url = getkey "tg_url"
let tg_username = getkey "username"
let tg_password = getkey "password"

