module Challonge.Lib.HttpHelpers

open Challonge.Lib.Config
open FSharp.Net

let urlstem = apiurlstem
let subdomain = subdomain

let defaultquery = [ ("api_key", apikey); ("subdomain", subdomain); ]

let GetFrom url q = let res = match q with
                              | null -> let r = Http.Request(url, query = defaultquery)                                        
                                        r
                              | _    -> let r = Http.Request(url, query = q) 
                                        r
                    res

let PostFrom url bv q = let r = Http.Request(url, bodyValues = bv, query=q, meth="POST") 
                        r

let DeleteFrom url q = let r = Http.Request(url, query=q, meth="delete") 
                       r               

let PutFrom url bv q = let r = Http.Request(url, query=q, bodyValues=bv, meth="put")
                       r

let Get url q = GetFrom url q
let Post url b = PostFrom url b defaultquery
let Delete url = DeleteFrom url defaultquery
let Put url b = PutFrom url b defaultquery
