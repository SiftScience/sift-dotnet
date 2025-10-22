# CHANGES

## 1.6.0 (2025-10-18)

### NuGet Package Updates
- Bumped `Newtonsoft.Json` from `13.0.2` to `13.0.4`
- Bumped `System.ComponentModel.Annotations` from `4.5.0` to `5.0.0`

### Breaking Changes
- **`$iata_carrier_code`** moved from `Booking` to `Segment` complex type (API v205 compliance)

### Added
- **`$exchange_rate`** field support in `$create_order`, `$update_order`, `$transaction`, `$wager` events and `$booking`, `$item`, `$discount` complex types
- **`$card_bin_metadata`** field in `$payment_method` complex type
- **`$promotions`** field in `$update_account` event
- **`$iata_carrier_code`** field in `Segment` complex type
- Apple Silicon (ARM64) native support (`osx-arm64` runtime)
- .NET 8.0 support (migrated integration tests from .NET 7)
- Comprehensive integration test coverage for all new fields

### Changed
- Renamed `Test.Integration.Net7` to `Test.Integration.Net` (targeting .NET 8.0)

## 1.5.0 (2024-12-24)

### Added
- iGaming Events API support
- New event type `$wager`
- Extra fields for `$deposit` and `$withdrawal` Transactions

## 1.4.0 (2024-09-27)

### Added
- Support for `$iata_carrier_code` field in `$booking` complex field

## 1.3.0 (2024-06-18)

### Added
- Warnings to Event Response

## 1.2.0 (2023-12-22)

### Fixed
- PSP Merchants API fixes

## 1.1.0 (2023-10-20)

### Added
- Score percentiles support in Score API

## 1.0.0 (2023-09-01)

### Changed
- Updates in Verification API (breaking changes - see README for examples)

## 0.13.0 (2023-08-31)

### Added
- Initial public release

## 0.12.0 (2023-08-28)

### Added
- Pre-release features

## 0.11.0-beta (2023-02-10)

### Added
- Beta release

## 0.10.1-beta (2022-12-05)

### Added
- Beta release
