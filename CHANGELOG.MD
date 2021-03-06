# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.2.0](https://github.com/TechJosh/AzureDynamicDNS/compare/1.1.0...1.2.0) - Current
### Added
- Dockerfile for building from git source.
- Docker Compose file for deploying quickly.
- Docker [ReadMe](azdyndns-docker/README.MD) - for basic setup.

### Changed
- Update [ReadMe](README.MD) to reflect changes made and swag tagline.
- Update links in Change Log file.

## [1.1.0](https://github.com/TechJosh/AzureDynamicDNS/compare/1.0.0...1.1.0) - 2022-06-05
### Added
 - Allow multiple records within the same subscription to be set at the same time in the config file.
 - Allow TTL to be set via config.
 - [ChangeLog](CHANGELOG.MD) - Change Log file (this).

### Changed
 - [ReadMe](README.MD) - Update documentation to reflect the additions above as well as usage and notes.

### Updated
 - CommandLineParser 2.8.0 to 2.9.1 - multiple bug fixes

## [1.0.0](https://github.com/TechJosh/AzureDynamicDNS/releases/tag/1.0.0) - 2022-01-14
### Added
 - Initial working release allowing a record to be updated on Azure DNS Zones.