# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.6.0] - 2025-10-18

### Summary

This release brings the sift-dotnet SDK into full compliance with Sift API v205 specifications, including critical updates for multi-currency support, enhanced fraud detection capabilities, and iGaming features.

**Key Highlights:**
- 🔄 **Breaking Change**: `$iata_carrier_code` moved from `Booking` to `Segment` (see migration guide below)
- 💱 Multi-currency transaction support via `$exchange_rate` field
- 🎁 Account promotions tracking in `$update_account` events
- 💳 Enhanced payment method validation with `$card_bin_metadata`
- 🎰 Complete iGaming support with enhanced `$transaction` and `$wager` events
- ✅ Comprehensive test coverage across all new features

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

- **.NET 8.0 migration**
  - Migrated integration tests from .NET 7 to .NET 8.0
  - Renamed `Test.Integration.Net7` project to `Test.Integration.Net`
  - Maintains backward compatibility with .NET Framework 4.8

#### Developer Experience

- **JetBrains IDE support**
  - Added `.idea/` directory to `.gitignore`
  - Better IDE integration for Rider and IntelliJ users

#### Test Coverage Enhancements

- **Comprehensive integration tests** across both .NET and .NET Framework 4.8:
  - Added test coverage for `$promotions` field in `$update_account` event
  - Enhanced `$transaction` event tests with deposit/withdrawal scenarios covering all new iGaming fields
  - Complete test coverage for `$wager` event with all fields including `$exchange_rate`
  - Validation tests for `$card_bin_metadata` in payment methods
  - All new fields verified with end-to-end integration tests

### Changed

- **Booking model**: Removed deprecated `iata_carrier_code` property (see Breaking Changes)
- **Segment model**: Added `iata_carrier_code` property
- **UpdateAccount model**: Added `promotions` array property
- **Transaction model**: Enhanced with `$exchange_rate` support for multi-currency transactions
- **Wager model**: Added `$exchange_rate` field for currency conversion tracking
- **Test projects**: Renamed `Test.Integration.Net7` to `Test.Integration.Net` (targeting .NET 8.0)
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

### Testing & Validation

- ✅ All 51 unit tests passing
- ✅ Comprehensive integration test coverage across .NET 8.0 and .NET Framework 4.8
- ✅ All new fields validated with end-to-end API integration tests
- ✅ Breaking changes verified with migration test scenarios
- ✅ Multi-currency exchange rate calculations validated
- ✅ iGaming transaction flows (deposits, withdrawals, wagers) fully tested

### Notes

This release brings the .NET SDK into full compliance with Sift API v205 specifications as of April 2025, including all reserved field updates from February through April 2025.

**Migration Support:**
- For complete `$iata_carrier_code` migration guidance, see [IATA_CARRIER_CODE_MIGRATION_SUMMARY.md](IATA_CARRIER_CODE_MIGRATION_SUMMARY.md)
- All changes are backward compatible except for the `$iata_carrier_code` field relocation
- Existing code using other fields will continue to work without modifications

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
   - **Multi-currency support**: Use `exchange_rate` fields in transactions, wagers, and orders
     ```csharp
     var transaction = new Transaction
     {
         amount = 100000000L,
         currency_code = "EUR",
         exchange_rate = new ExchangeRate
         {
             quote_currency_code = "USD",
             rate = 1.14
         }
     };
     ```
   - **Enhanced payment validation**: Use `card_bin_metadata` for detailed card information
     ```csharp
     payment_method = new PaymentMethod
     {
         card_bin = "542486",
         card_bin_metadata = new CardBinMetadata
         {
             bank = "Chase",
             brand = "VISA",
             country = "US",
             level = "Gold",
             type = "CREDIT"
         }
     };
     ```
   - **Account promotions tracking**: Use `promotions` in `$update_account` events
     ```csharp
     var updateAccount = new UpdateAccount
     {
         promotions = new ObservableCollection<Promotion>()
         {
             new Promotion()
             {
                 promotion_id = "SUMMER2025",
                 status = "$success",
                 discount = new Discount()
                 {
                     amount = 5000000,
                     currency_code = "USD"
                 }
             }
         }
     };
     ```

### Compatibility

- ✅ Compatible with Sift API v205
- ✅ .NET Standard 2.0
- ✅ Supports .NET Framework 4.6.1+, .NET Core 2.0+, .NET 5.0+
- ✅ Native Apple Silicon (M1/M2/M3) support

---

[1.6.0]: https://github.com/siftscience/sift-dotnet/compare/v1.5.0...v1.6.0
[1.5.0]: https://github.com/siftscience/sift-dotnet/compare/v1.4.0...v1.5.0
[1.4.0]: https://github.com/siftscience/sift-dotnet/releases/tag/v1.4.0
