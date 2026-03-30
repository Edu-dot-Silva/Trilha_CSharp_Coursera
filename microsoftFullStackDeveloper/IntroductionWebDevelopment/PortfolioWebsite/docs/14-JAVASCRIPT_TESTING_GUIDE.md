# JavaScript Testing & Debugging Guide

## 🧪 Complete Testing Checklist for Activity 4

This guide provides 20+ practical tests to verify all JavaScript features are working correctly.

---

## ✅ Test 1: Basic Page Load

**Purpose**: Verify JavaScript initializes correctly

**Steps**:
1. Open `index.html` in browser
2. Open DevTools (F12) → Console tab
3. Refresh page

**Expected**:
```
[Portfolio] Initializing hamburger menu...
[Portfolio] Enabling smooth scrolling...
[Portfolio] Initializing project filtering...
[Portfolio] Initializing lightbox...
[Portfolio] Initializing form validation...
[Portfolio] Initializing dark mode toggle...
[Portfolio] Initializing scroll animations...
```

**Status**: ✅ Pass if all logs appear, no errors in red

---

## ✅ Test 2: Hamburger Menu Creation

**Purpose**: Verify mobile menu is created

**Steps**:
1. Open DevTools → Inspector tab
2. Search for `.hamburger` element
3. Check HTML structure

**Expected**:
```html
<div class="hamburger" aria-label="..." role="button" tabindex="0">
    <span></span>
    <span></span>
    <span></span>
</div>
```

**Status**: ✅ Pass if element exists with 3 spans

---

## ✅ Test 3: Hamburger Menu Click

**Purpose**: Verify hamburger toggles menu

**Steps**:
1. Resize browser to mobile width (< 768px)
2. Click hamburger icon
3. Verify menu appears
4. Click again
5. Verify menu disappears

**Expected**:
- Menu slides in from left
- Hamburger icon changes to X shape
- Menu has semi-transparent overlay

**Status**: ✅ Pass if menu toggles smoothly

---

## ✅ Test 4: Hamburger Menu Keyboard

**Purpose**: Verify keyboard accessibility

**Steps**:
1. Resize to mobile width
2. Tab to hamburger
3. Press Space or Enter

**Expected**:
- Menu toggles
- Focus visible on hamburger
- Tab continues to navigate

**Status**: ✅ Pass if keyboard works

---

## ✅ Test 5: Close Menu on Link Click

**Purpose**: Verify menu closes when selecting link

**Steps**:
1. Resize to mobile (< 768px)
2. Click hamburger to open
3. Click "About Me" link
4. Observe menu

**Expected**:
- Menu closes automatically
- Page scrolls to About section
- No hamburger visible on desktop

**Status**: ✅ Pass if menu closes

---

## ✅ Test 6: Smooth Scrolling

**Purpose**: Verify smooth scroll works

**Steps**:
1. Click "Projects" in navigation
2. Watch scroll movement
3. Observe target section

**Expected**:
- Smooth animation (not instant jump)
- Page scrolls to Projects section
- Section gets visual focus

**Links to test**:
- About Me → About section
- Projects → Projects section
- Skills → Skills section
- Contact → Contact section

**Status**: ✅ Pass all 4 links smoothly scroll

---

## ✅ Test 7: Smooth Scroll Focus

**Purpose**: Verify focus management

**Steps**:
1. Click "About Me" link
2. With DevTools, check which element has focus
3. Press Tab

**Expected**:
- Focus moves to About section first element
- Tab continues from there
- Visible focus outline present

**Status**: ✅ Pass if focus moves correctly

---

## ✅ Test 8: Active Nav Tracking

**Purpose**: Verify active nav updates while scrolling

**Steps**:
1. Scroll down page slowly
2. Watch navigation bar
3. Note which link highlights

**Expected**:
- "About Me" highlights when in About section
- "Projects" highlights when in Projects section
- "Skills" highlights when in Skills section
- "Contact" highlights when in Contact section

**Status**: ✅ Pass if nav updates correctly

---

## ✅ Test 9: Filter Buttons Creation

**Purpose**: Verify filter buttons are created

**Steps**:
1. Open DevTools → Inspector
2. Find `.filter-container`
3. Check buttons

**Expected**:
```html
<div class="filter-container">
    <button class="filter-btn active" data-filter="all">All Projects</button>
    <button class="filter-btn" data-filter="frontend">Frontend</button>
    <button class="filter-btn" data-filter="backend">Backend</button>
    <button class="filter-btn" data-filter="fullstack">Full Stack</button>
</div>
```

**Status**: ✅ Pass if 4 buttons exist

---

## ✅ Test 10: Filter "All Projects"

**Purpose**: Verify filter shows all projects

**Steps**:
1. Click "All Projects" button
2. Count visible project cards
3. Check console

**Expected**:
- All project cards visible
- "All Projects" button highlighted
- Console shows: `[Portfolio] Filtering projects for category: all`

**Status**: ✅ Pass if all projects show

---

## ✅ Test 11: Filter "Frontend"

**Purpose**: Verify frontend filter works

**Steps**:
1. Click "Frontend" button
2. Count visible projects
3. Check each has `data-category="frontend"`

**Expected**:
- Only frontend projects visible
- Others hidden
- "Frontend" button highlighted
- Console shows: `[Portfolio] Filtering projects for category: frontend`

**Status**: ✅ Pass if only frontend projects show

---

## ✅ Test 12: Filter "Backend"

**Purpose**: Verify backend filter works

**Steps**:
1. Click "Backend" button
2. Count visible projects
3. Check each has `data-category="backend"`

**Expected**:
- Only backend projects visible
- Others hidden
- "Backend" button highlighted

**Status**: ✅ Pass if only backend projects show

---

## ✅ Test 13: Filter "Full Stack"

**Purpose**: Verify full stack filter works

**Steps**:
1. Click "Full Stack" button
2. Count visible projects
3. Check each has `data-category="fullstack"`

**Expected**:
- Only full stack projects visible
- Others hidden
- "Full Stack" button highlighted

**Status**: ✅ Pass if only full stack projects show

---

## ✅ Test 14: Filter Animation

**Purpose**: Verify fade animation on filter

**Steps**:
1. Click "Frontend"
2. Watch hidden projects
3. Click "All Projects"
4. Watch projects reappear

**Expected**:
- Projects fade out smoothly
- Projects fade in smoothly
- Transition takes ~0.3 seconds

**Status**: ✅ Pass if smooth fade animation

---

## ✅ Test 15: Lightbox Image Click

**Purpose**: Verify lightbox opens on image click

**Steps**:
1. Find first project image in Projects section
2. Click the image
3. Observe lightbox

**Expected**:
- Modal overlay appears (dark background)
- Image displayed large in center
- Alt text shows as caption
- Close button (X) visible
- Background scrolling prevented

**Status**: ✅ Pass if lightbox opens

---

## ✅ Test 16: Lightbox Close Button

**Purpose**: Verify X button closes lightbox

**Steps**:
1. Click project image to open
2. Click X button (top right)
3. Observe lightbox

**Expected**:
- Lightbox closes
- Overlay disappears
- Background becomes scrollable again

**Status**: ✅ Pass if closes smoothly

---

## ✅ Test 17: Lightbox Click Outside

**Purpose**: Verify clicking outside closes lightbox

**Steps**:
1. Click project image to open
2. Click on dark area (not image)
3. Observe lightbox

**Expected**:
- Lightbox closes
- Overlay disappears
- Image stays visible

**Status**: ✅ Pass if closes on outside click

---

## ✅ Test 18: Lightbox Escape Key

**Purpose**: Verify Escape closes lightbox

**Steps**:
1. Click project image to open
2. Press Escape key
3. Observe lightbox

**Expected**:
- Lightbox closes
- Overlay disappears
- DevTools shows no errors

**Status**: ✅ Pass if closes with Escape

---

## ✅ Test 19: Form Email Required

**Purpose**: Verify email field is required

**Steps**:
1. Scroll to Contact section
2. Fill all fields except email
3. Click Submit

**Expected**:
- Form does not submit
- Email input gets red border
- Error message appears: "Email is required"
- Console shows validation error

**Status**: ✅ Pass if validation triggers

---

## ✅ Test 20: Form Email Validation

**Purpose**: Verify email format validation

**Steps**:
1. Enter invalid email: "notanemail"
2. Click outside (blur)
3. Observe error

**Expected**:
- Red border on email field
- Error message: "Please enter a valid email address"
- Form submission blocked

**Valid emails to test**:
- user@example.com ✅
- john.doe@company.co.uk ✅
- test@domain.org ✅

**Invalid emails to test**:
- notanemail ❌
- user@domain ❌
- @example.com ❌

**Status**: ✅ Pass if validation works

---

## ✅ Test 21: Form Name Validation

**Purpose**: Verify name field validation

**Steps**:
1. Enter name: "A" (too short)
2. Click outside (blur)
3. Observe error

**Expected**:
- Red border on name field
- Error message: "Name must be at least 2 characters"
- Valid names (2+): "Jo", "Eduardo", "John Doe" ✅

**Status**: ✅ Pass if validation works

---

## ✅ Test 22: Form Message Validation

**Purpose**: Verify message field validation

**Steps**:
1. Enter message: "Hi" (too short)
2. Click outside (blur)
3. Observe error

**Expected**:
- Red border on message field
- Error message: "Message must be at least 10 characters"
- Short message "Hi" gets error ❌
- Long message "Hello, this is my message" OK ✅

**Status**: ✅ Pass if validation works

---

## ✅ Test 23: Form Valid Submission

**Purpose**: Verify form submits with valid data

**Steps**:
1. Fill all fields:
   - Name: "Eduardo"
   - Email: "edu@example.com"
   - Subject: "Portfolio Inquiry"
   - Message: "I'm interested in your work. Great portfolio!"
2. Click Submit

**Expected**:
- No red borders
- No error messages
- Form clears
- Success message appears: "Thank you! Your message has been sent successfully."
- Success message lasts 5 seconds then disappears
- Console shows: `Form submitted successfully`

**Status**: ✅ Pass if success message appears

---

## ✅ Test 24: Form Real-Time Validation

**Purpose**: Verify validation on input change

**Steps**:
1. Click email field
2. Type "notanemail"
3. Click outside (blur)
4. Type "user@example.com"
5. Observe validation

**Expected**:
- Invalid format gets error
- Valid format clears error
- Error disappears when corrected
- No red border after valid input

**Status**: ✅ Pass if real-time validation works

---

## ✅ Test 25: Dark Mode Detection

**Purpose**: Verify dark mode respects system preference

**Steps**:
1. Check system dark mode setting
2. Refresh page
3. Observe theme

**Expected**:
- If system dark: Page loads in dark mode
- If system light: Page loads in light mode
- Matches OS preference

**How to change system preference** (Windows):
- Settings → Personalization → Colors → Choose your mode

**Status**: ✅ Pass if theme matches OS

---

## ✅ Test 26: Dark Mode Toggle

**Purpose**: Verify dark mode can be toggled

**Steps**:
1. Inspect page (right-click → Inspect)
2. Find dark mode toggle (check HTML for button)
3. Click toggle
4. Observe theme change

**Expected**:
- Theme switches from light to dark or vice versa
- Refresh page
- Theme persists (saved in localStorage)

**Status**: ✅ Pass if toggle works and persists

---

## ✅ Test 27: Scroll Animations

**Purpose**: Verify fade-in animations on scroll

**Steps**:
1. Open page at top
2. Scroll down slowly
3. Watch each section

**Expected**:
- About section fades in smoothly
- Projects section fades in smoothly
- Skills section fades in smoothly
- Contact section fades in smoothly
- Animation once per section
- Uses IntersectionObserver (efficient)

**Status**: ✅ Pass if sections fade in

---

## ✅ Test 28: Mobile Responsive

**Purpose**: Verify responsive design with JavaScript

**Steps**:
1. Resize browser to:
   - 1200px (desktop)
   - 768px (tablet)
   - 480px (mobile)
2. Test each feature

**Expected on each size**:
- 1200px: Nav visible, no hamburger
- 768px: Hamburger visible, nav hidden
- 480px: Full mobile layout

**Features to test mobile**:
- Hamburger menu
- Smooth scrolling
- Project filtering
- Lightbox
- Form validation

**Status**: ✅ Pass all sizes work

---

## ✅ Test 29: Keyboard Navigation

**Purpose**: Verify full keyboard accessibility

**Commands**:
- Tab: Navigate forward
- Shift+Tab: Navigate backward
- Enter/Space: Activate buttons
- Escape: Close modals

**Steps**:
1. Start at top
2. Press Tab repeatedly (5+ times)
3. Verify focus visible on each element
4. Test buttons with Enter/Space
5. Open lightbox, press Escape

**Expected**:
- All interactive elements focusable
- Focus outline always visible
- Buttons activate with Space/Enter
- Escape closes lightbox
- Tab order logical

**Status**: ✅ Pass all keyboard tests

---

## ✅ Test 30: Console Errors

**Purpose**: Verify no JavaScript errors

**Steps**:
1. Open DevTools (F12)
2. Go to Console tab
3. Perform all features
4. Check for red errors

**Expected**:
- NO red error messages
- Only info/log messages in blue
- Warnings (yellow) are OK
- Console clean after all tests

**Status**: ✅ Pass if zero red errors

---

## 🔍 Debugging Checklist

### If Hamburger Menu Not Working:

```
1. Check browser console for errors
2. Verify hamburger element exists (Inspect → .hamburger)
3. Check CSS loaded (DevTools → Styles → hamburger)
4. Check script.js loaded (DevTools → Sources → script.js)
5. Verify screen width < 768px for hamburger to show
```

### If Form Validation Not Working:

```
1. Check input elements have name attribute
2. Verify email regex: /^[^\s@]+@[^\s@]+\.[^\s@]+$/
3. Check .contact-form class exists
4. Verify validateField function called on blur
5. Check error class added to invalid inputs
```

### If Lightbox Not Working:

```
1. Verify img tags in project sections
2. Check .lightbox div created (Inspect)
3. Verify click handler added to images
4. Check lightbox CSS loaded
5. Test image src paths are correct
```

### If Filtering Not Working:

```
1. Verify project cards have data-category attribute
2. Check filter buttons created (.filter-container)
3. Verify filterProjects function called on button click
4. Check CSS display property in styles.css
5. Ensure project-card class exists
```

### If Scroll Animations Not Working:

```
1. Check Intersection Observer supported (modern browser)
2. Verify sections have fade animation class
3. Check @keyframes fadeInUp exists in CSS
4. Verify scroll listener attached
5. Test IntersectionObserver in console
```

---

## 🛠️ Developer Tools Tips

### Open DevTools:
- **Windows/Linux**: F12 or Ctrl+Shift+I
- **Mac**: Cmd+Option+I

### Useful Tabs:
- **Console**: View logs and errors
- **Inspector**: Inspect HTML/CSS
- **Sources**: Debug JavaScript

### Debug Tips:

```javascript
// Add breakpoint: Click line number in Sources
// Add console.log: console.log('Debug message', variable);
// Watch variable: console.watch('variable');
// Pause on error: Right-click → Pause on exceptions
// Check element: Right-click element → Inspect
```

### Check localStorage:
```javascript
// In Console:
localStorage.getItem('darkMode') // Check dark mode setting
localStorage.clear() // Clear all storage
```

---

## 📊 Test Results Template

Copy and use this to track test results:

```
Test Results - Portfolio Activity 4
Date: _______________
Browser: _______________
Screen Size: _______________

[ ] Test 1: Page Load
[ ] Test 2: Hamburger Menu Creation
[ ] Test 3: Hamburger Menu Click
[ ] Test 4: Hamburger Menu Keyboard
[ ] Test 5: Close Menu on Link Click
[ ] Test 6: Smooth Scrolling
[ ] Test 7: Smooth Scroll Focus
[ ] Test 8: Active Nav Tracking
[ ] Test 9: Filter Buttons Creation
[ ] Test 10: Filter "All Projects"
[ ] Test 11: Filter "Frontend"
[ ] Test 12: Filter "Backend"
[ ] Test 13: Filter "Full Stack"
[ ] Test 14: Filter Animation
[ ] Test 15: Lightbox Image Click
[ ] Test 16: Lightbox Close Button
[ ] Test 17: Lightbox Click Outside
[ ] Test 18: Lightbox Escape Key
[ ] Test 19: Form Email Required
[ ] Test 20: Form Email Validation
[ ] Test 21: Form Name Validation
[ ] Test 22: Form Message Validation
[ ] Test 23: Form Valid Submission
[ ] Test 24: Form Real-Time Validation
[ ] Test 25: Dark Mode Detection
[ ] Test 26: Dark Mode Toggle
[ ] Test 27: Scroll Animations
[ ] Test 28: Mobile Responsive
[ ] Test 29: Keyboard Navigation
[ ] Test 30: Console Errors

PASS RATE: ____/30 (____%)
NOTES: _______________
```

---

## 🎯 Testing Quick Start

**Want to test quickly?**

1. Open index.html in browser
2. Press F12 to open DevTools
3. Run these checks:

```javascript
// In Console, paste these:

// Check hamburger exists
document.querySelector('.hamburger') ? '✅ Hamburger OK' : '❌ Hamburger missing'

// Check filters exist
document.querySelector('.filter-container') ? '✅ Filters OK' : '❌ Filters missing'

// Check lightbox exists
document.querySelector('#lightbox') ? '✅ Lightbox OK' : '❌ Lightbox missing'

// Check form exists
document.querySelector('.contact-form') ? '✅ Form OK' : '❌ Form missing'

// Check localStorage
localStorage.getItem('darkMode') ? '✅ Dark mode saved' : '❌ Dark mode not saved'
```

---

## 📚 Related Documentation

- [ACTIVITY_4_JAVASCRIPT_REPORT.md](ACTIVITY_4_JAVASCRIPT_REPORT.md) - Feature details
- [JAVASCRIPT_DEBUGGING_GUIDE.md](JAVASCRIPT_DEBUGGING_GUIDE.md) - Troubleshooting guide
- [README.md](README.md) - Project overview

---

**Testing Guide Complete** ✅

**All 30 tests ensure Activity 4 is production-ready!**

---
