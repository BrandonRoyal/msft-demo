#Issues

* Docker Compose does not natively connect to Docker Daemon - requires unsecure tcp:\\ host mapping
* Docker Compose cannot create networks for apply network changes
* Environment variables on `docker run -e <KEY=VALUE>` not being parsed and applied
* Links not being applied to hosts file using `docker run --links <link_mapping`
* Network cannot be created using `docker network create <network_name>`
* Networking between containers not possible (e.g. internal IPs are not accessible on the same network) on Windows Server 2016 Preview with Containers