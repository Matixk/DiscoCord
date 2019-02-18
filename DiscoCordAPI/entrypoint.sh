#!/bin/bash

set -e
run_cmd="dotnet watch run --no-restore --urls https://0.0.0.0:5000"

cd DiscoCordAPI.Web.Api
until dotnet ef database update; do
>&2 echo "SQL Server connecting..."
sleep 1
done

>&2 echo "SQL Server is up - executing command"
exec $run_cmd