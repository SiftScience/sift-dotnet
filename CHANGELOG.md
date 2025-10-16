# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.6.0] - 2025-01-XX

### Breaking Changes

#### ⚠️ iata_carrier_code Migration (February 2025 API Change)

The `$iata_carrier_code` field has been moved from the `Booking` complex type to the `Segment` complex type to properly represent IATA codes at the segment level for flights.

**Migration Required:**

```csharp
// BEFORE (v1.5.0 and earlier) - NO LONGER WORKS
var booking = new Booking
{
    iata_carrier_code = "AS",  // ❌ This property no longer exists
    segments = new ObservableCollection<Segment>()
    {
        new Segment() { /* ... */ }
    }
};

// AFTER (v1.6.0+) - REQUIRED
var booking = new Booking
{
    segments = new ObservableCollection<Segment>()
    {
        new Segment() 
        { 
            iata_carrier_code = "AS",  // ✅ Now at segment level
            departure_airport_code = "SFO",
            arrival_airport_code = "LAS",
            /* ... */
        }
    }
};
```

**Why this change?** This aligns with Sift's API v205 specification where IATA carrier codes are specific to each flight segment, not the overall booking.

### Added

#### API Compliance Updates (February-April 2025)

- **`$exchange_rate` field** (April 2025)
  - Added to events: `$create_order`, `$update_order`, `$transaction`, `$wager`
  - Added to complex types: `$booking`, `$item`, `$discount`
  - Supports currency exchange rate tracking with quote currency and rate
  
- **`$card_bin_metadata` field** (March 2025)
  - Added to `$payment_method` complex type
  - Provides detailed card BIN (Bank Identification Number) metadata
  
- **`$promotions` field** (April 2025)
  - Added to `$update_account` event
  - Allows tracking promotion changes during account updates
  
- **`$iata_carrier_code` field** (February 2025)
  - Added to `Segment` complex type (for flight segments)
  - Properly represents IATA airline codes at the segment level

#### Platform Support

- **Apple Silicon (ARM64) support**
  - Added `osx-arm64` runtime identifier
  - Native support for M1, M2, and M3 Mac processors

#### Developer Experience

- **JetBrains IDE support**
  - Added `.idea/` directory to `.gitignore`
  - Better IDE integration for Rider and IntelliJ users

### Changed

- **Booking model**: Removed deprecated `iata_carrier_code` property (see Breaking Changes)
- **Segment model**: Added `iata_carrier_code` property
- **UpdateAccount model**: Added `promotions` array property
- **Package version**: Updated to 1.6.0

### Deprecated

- **Booking.iata_carrier_code** (removed in v1.6.0)
  - Deprecated in Sift API v205 (February 2025)
  - Replaced by `Segment.iata_carrier_code`

### Technical Details

#### New Complex Types

- **ExchangeRate**
  - `quote_currency_code` (string): The currency code for the quote
  - `rate` (double): The exchange rate value

- **CardBinMetadata**
  - Provides card BIN information for payment methods

#### Schema Updates

The following JSON schema files were updated:

**Events:**
- `create_order.json` - Added `$exchange_rate`
- `update_order.json` - Added `$exchange_rate`
- `transaction.json` - Added `$exchange_rate`
- `wager.json` - Added `$exchange_rate`
- `update_account.json` - Added `$promotions`

**Complex Types:**
- `booking.json` - Added `$exchange_rate`, removed `$iata_carrier_code`
- `item.json` - Added `$exchange_rate`
- `discount.json` - Added `$exchange_rate`
- `segment.json` - Added `$iata_carrier_code`
- `payment_method.json` - Added `$card_bin_metadata`

### Notes

This release brings the .NET SDK into full compliance with Sift API v205 specifications as of April 2025, including all reserved field updates from February through April 2025.

For complete migration guidance, see [IATA_CARRIER_CODE_MIGRATION_SUMMARY.md](IATA_CARRIER_CODE_MIGRATION_SUMMARY.md).

---

## [1.5.0] - 2024-XX-XX

### Added
- iGaming Events API support
- Additional reserved fields for gaming/wagering use cases

### Changed
- Updated API version compatibility

---

## [1.4.0] - 2023-XX-XX

### Added
- Support for complex fields in events
- Enhanced event validation

---

## Earlier Releases

For earlier release notes, see [GitHub Releases](https://github.com/siftscience/sift-dotnet/releases).

---

## Upgrade Guide

### From 1.5.x to 1.6.0

1. **Update package reference:**
   ```xml
   <PackageReference Include="Sift" Version="1.6.0" />
   ```

2. **Update iata_carrier_code usage** (if applicable):
   - Find all instances of `booking.iata_carrier_code`
   - Move to `segment.iata_carrier_code` within the segments array
   - See Breaking Changes section above for code examples

3. **Verify builds and tests:**
   - Rebuild your project
   - Run all tests, especially those involving flight bookings
   - Update any tests that reference `booking.iata_carrier_code`

4. **Optional: Leverage new features:**
   - Use `exchange_rate` fields for multi-currency transactions
   - Use `card_bin_metadata` for enhanced payment method tracking
   - Use `promotions` in account update events

### Compatibility

- ✅ Compatible with Sift API v205
- ✅ .NET Standard 2.0
- ✅ Supports .NET Framework 4.6.1+, .NET Core 2.0+, .NET 5.0+
- ✅ Native Apple Silicon (M1/M2/M3) support

---

[1.6.0]: https://github.com/siftscience/sift-dotnet/compare/v1.5.0...v1.6.0
[1.5.0]: https://github.com/siftscience/sift-dotnet/compare/v1.4.0...v1.5.0
[1.4.0]: https://github.com/siftscience/sift-dotnet/releases/tag/v1.4.0
