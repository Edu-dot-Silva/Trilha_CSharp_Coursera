# JavaScript Debugging & Troubleshooting Guide

## 🐛 Troubleshooting Activity 4 JavaScript

If you encounter issues with JavaScript features, use this guide to find and fix them.

---

## ❓ Common Issues & Solutions

### Issue 1: "Script.js is not loading"

**Symptoms**:
- Features not working (no menu toggle, no filtering, etc.)
- Console shows no log messages
- No errors but features dead

**Causes**:
1. Wrong file path in HTML
2. File not in correct location
3. Server not serving files
4. Script tag in wrong location

**Solutions**:

**Step 1**: Check HTML script tag
```html
<!-- In index.html, near bottom of <body>: -->
<script src="script.js"></script>

<!-- ❌ WRONG: -->
<script src="../script.js"></script>
<script src="/script.js"></script>
<script src="C:\path\to\script.js"></script>
```

**Step 2**: Verify file location
```
Trilha_CSharp_Coursera/
└── microsoftFullStackDeveloper/
    └── IntroductionWebDevelopment/
        └── PortfolioWebsite/
            ├── index.html ✅
            ├── styles.css ✅
            └── script.js ✅ (MUST be in same folder)
```

**Step 3**: Check DevTools
```
1. Open DevTools (F12)
2. Go to Sources tab
3. Look for script.js in file tree
4. If missing: File not served correctly
5. If present: File loaded (check Console for logs)
```

**Step 4**: Re-download script.js
- Delete script.js
- Copy-paste complete content again
- Save file

---

### Issue 2: "Hamburger menu button not appearing"

**Symptoms**:
- Can't find hamburger icon
- Mobile menu not visible on small screens
- No icon in top right

**Causes**:
1. CSS not loaded or broken
2. Screen too wide for hamburger
3. JavaScript not creating element
4. Display property set to none

**Solutions**:

**Check CSS is loaded**:
```
1. DevTools → Sources tab
2. Find styles.css in list
3. Open it
4. Search for ".hamburger"
5. Should have styling code
```

**Check screen size**:
```
1. Resize browser to < 768px width
2. Hamburger should appear
3. At desktop width (1200px) hamburger hidden (intentional)
```

**Check element exists**:
```
1. Right-click page → Inspect
2. Search (Ctrl+F) for "hamburger"
3. Should find: <div class="hamburger" ...>
4. If not found: JavaScript not running
```

**Check console**:
```
1. Open DevTools → Console
2. Refresh page
3. Look for: "[Portfolio] Initializing hamburger menu..."
4. If not there: script.js not loaded
```

**Fix**:
```javascript
// In script.js, add console check:
console.log('[Portfolio] Script loaded, page ready state:', document.readyState);

// Make sure DOMContentLoaded event fires:
document.addEventListener('DOMContentLoaded', () => {
    console.log('[Portfolio] DOM Ready!');
    initializeAll();
});
```

---

### Issue 3: "Smooth scrolling not working"

**Symptoms**:
- Page jumps instantly to section
- No smooth animation
- Links still navigate but no transition

**Causes**:
1. CSS scroll-behavior not set
2. Smooth scrolling code not running
3. Browser doesn't support smooth scroll
4. JavaScript preventing default

**Solutions**:

**Step 1**: Check CSS
```css
/* In styles.css, add: */
html {
    scroll-behavior: smooth;
}
```

**Step 2**: Check JavaScript event listener
```javascript
// In script.js, verify this exists:
function enableSmoothScrolling() {
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            // ... scroll code
        });
    });
}
```

**Step 3**: Verify it's called
```
1. Open Console
2. Type: typeof enableSmoothScrolling
3. Should return: "function"
4. Type in Console: enableSmoothScrolling()
5. Test clicking a link
```

**Step 4**: Test manually
```javascript
// Test in console:
document.querySelector('a[href="#about"]').click()
// Should scroll to about section
```

---

### Issue 4: "Project filtering buttons not appearing"

**Symptoms**:
- No filter buttons above project cards
- Can't filter by Front End/Back End
- Project section empty

**Causes**:
1. Project cards don't have data-category
2. Filter buttons CSS broken
3. initProjectFiltering not running
4. categorizeProjects not matching categories

**Solutions**:

**Step 1**: Check project cards have categories
```html
<!-- Each project card needs data-category: -->
<article class="project-card" data-category="fullstack">
    <!-- content -->
</article>

<!-- Not: -->
<article class="project-card">  ❌
<!-- OR -->
<article class="project-card" data-category="">  ❌
```

**Step 2**: Check filter buttons creation
```
1. Inspect page (Ctrl+Shift+I)
2. Search for "filter-btn"
3. Should find 4 buttons:
   - data-filter="all"
   - data-filter="frontend"
   - data-filter="backend"
   - data-filter="fullstack"
```

**Step 3**: Check categorizeProjects function
```javascript
// In script.js, should assign categories:
function categorizeProjects() {
    const projectCards = document.querySelectorAll('.project-card');
    projectCards.forEach(card => {
        if (!card.hasAttribute('data-category')) {
            // Auto-assign category
            const name = card.querySelector('h3')?.textContent || '';
            if (name.includes('API')) {
                card.setAttribute('data-category', 'backend');
            } // ... more logic
        }
    });
}
```

**Step 4**: Test in console
```javascript
// Check if function exists:
typeof filterProjects // Should be "function"

// Call it:
filterProjects('frontend') // Should filter to frontend
filterProjects('all') // Should show all
```

---

### Issue 5: "Lightbox not opening when clicking images"

**Symptoms**:
- Click image, nothing happens
- No modal dialog appears
- Lightox feature broken

**Causes**:
1. Lightbox modal not created
2. Click handler not attached
3. CSS display broken
4. Image selector wrong

**Solutions**:

**Step 1**: Check lightbox element exists
```
1. Inspect page
2. Search for id="lightbox"
3. Should find: <div id="lightbox" class="lightbox">
4. If not: initLightbox not running
```

**Step 2**: Check image click handlers
```javascript
// In script.js:
function initLightbox() {
    const projectSection = document.querySelector('#projects');
    if (projectSection) {
        const images = projectSection.querySelectorAll('img');
        images.forEach(img => {
            img.addEventListener('click', function() {
                openLightbox(this.src, this.alt);
            });
        });
    }
    // ... more code
}
```

**Step 3**: Verify images clickable
```
1. Find image in projects
2. Check if it has class="clickable" or click handler
3. Right-click → Inspect
4. Should have: onclick or click listener
```

**Step 4**: Test manually
```javascript
// In console:
openLightbox('/path/to/image.jpg', 'Image alt text')
// Lightbox should open
```

**Step 5**: Check CSS
```css
/* Lightbox should have: */
.lightbox {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    opacity: 0;
    visibility: hidden;
}

.lightbox.active {
    opacity: 1;
    visibility: visible;
}
```

---

### Issue 6: "Form validation not working"

**Symptoms**:
- Can submit empty form
- Invalid email accepted
- No error messages
- Red borders not appearing

**Causes**:
1. Form doesn't have correct classes/IDs
2. Input fields missing name attribute
3. validateForm not being called
4. Error styling not in CSS

**Solutions**:

**Step 1**: Check form structure
```html
<!-- Form needs class="contact-form": -->
<form class="contact-form">
    <!-- Inputs need name attribute: -->
    <input type="text" name="name" ... />
    <input type="email" name="email" ... />
    <input type="text" name="subject" ... />
    <textarea name="message"></textarea>
</form>
```

**Step 2**: Check validation function
```javascript
// In script.js, should validate on submit:
function submitForm(form) {
    if (validateForm(form)) {
        // Validation passed
        console.log('Form submitted successfully');
    } else {
        // Validation failed
        console.log('Form has errors');
    }
}
```

**Step 3**: Test validation
```javascript
// In console:
const form = document.querySelector('.contact-form');
validateForm(form) // Should return true/false
```

**Step 4**: Check CSS error styles
```css
/* Should have error styling: */
input.error {
    border-color: #ef4444; /* Red border */
}

.error-message {
    color: #ef4444;
}
```

**Step 5**: Check email regex
```javascript
// Email validation pattern:
const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
emailRegex.test('user@example.com') // true ✅
emailRegex.test('invalid') // false ❌
```

---

### Issue 7: "Dark mode not working"

**Symptoms**:
- Dark mode toggle doesn't work
- Style doesn't change
- Preference not saved
- Wrong theme on refresh

**Causes**:
1. CSS dark mode styles missing
2. localStorage not working
3. enableDarkMode function broken
4. Toggle button not found

**Solutions**:

**Step 1**: Check CSS dark mode
```css
/* In styles.css, should have: */
@media (prefers-color-scheme: dark) {
    :root {
        --bg-color: #1a1a1a;
        --text-color: #ffffff;
        /* ... more variables */
    }
}
```

**Step 2**: Check dark mode functions
```javascript
// Should have these functions:
function enableDarkMode() { /* add dark class */ }
function disableDarkMode() { /* remove dark class */ }

// Should save preference:
localStorage.setItem('darkMode', 'enabled');
```

**Step 3**: Test localStorage
```javascript
// In console:
localStorage.setItem('darkMode', 'enabled');
localStorage.getItem('darkMode') // Should return: "enabled"
localStorage.clear() // Clear all
```

**Step 4**: Toggle manually
```javascript
// In console:
enableDarkMode() // Apply dark mode
disableDarkMode() // Remove dark mode
```

**Step 5**: Check HTML attributes
```html
<!-- Root element might need dark class: -->
<html class="dark">
    <!-- OR body: -->
</html>
<body class="dark">
    <!-- OR use CSS variable: -->
</body>
```

---

### Issue 8: "Scroll animations not working"

**Symptoms**:
- Sections don't fade in
- No animation on scroll
- All sections visible immediately
- IntersectionObserver errors

**Causes**:
1. Intersection Observer not supported (old browser)
2. Fade animation CSS missing
3. Observer not attached
4. Visibility already set on elements

**Solutions**:

**Step 1**: Check IntersectionObserver support
```javascript
// In console:
typeof IntersectionObserver // Should be "function"
// If not: Browser too old or disabled
```

**Step 2**: Check fade animation CSS
```css
/* In styles.css, should have: */
@keyframes fadeInUp {
    from {
        opacity: 0;
        transform: translateY(20px);
    }
    to {
        opacity: 1;
        transform: translateY(0);
    }
}

/* Apply to sections: */
section {
    animation: fadeInUp 0.6s ease forwards;
}
```

**Step 3**: Test manually
```javascript
// Force animation in console:
const section = document.querySelector('#about');
section.style.animation = 'fadeInUp 0.6s ease forwards';
```

**Step 4**: Check observer setup
```javascript
// In script.js:
function initScrollAnimations() {
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('animated');
            }
        });
    });
    // Observe sections...
}
```

---

## 🔧 Debugging Techniques

### 1. Use Console Logging

```javascript
// Add logs to track execution:
console.log('[Portfolio] Starting feature X');
console.log('Variable value:', variable);
console.table(data); // Pretty print arrays/objects
console.warn('Warning message');
console.error('Error message');
```

### 2. Use Debugger Breakpoints

```
1. Open DevTools (F12)
2. Go to Sources tab
3. Click line number to add breakpoint
4. Refresh page
5. Execution pauses at breakpoint
6. Use buttons to Step/Step Into/Step Over
7. Watch variables in panel
```

### 3. Check Network Requests

```
1. Open DevTools
2. Go to Network tab
3. Refresh page
4. Check:
   - script.js loaded (200 status)
   - styles.css loaded (200 status)
   - No 404 errors
```

### 4. Monitor Console Continuously

```
1. Keep console open while using site
2. Perform feature (click button, submit form)
3. Watch for error messages
4. Note timestamps of events
```

### 5. Use Chrome DevTools Features

**Pause on Exception**:
```
1. Sources tab
2. Right-click line numbers
3. "Pause on exceptions"
4. Refresh and test
```

**Watch Expressions**:
```
1. Sources → Watch panel
2. Click +
3. Type variable name
4. Watch value as code runs
```

**Local Storage Inspector**:
```
1. Application tab
2. Left sidebar → Storage
3. Click localStorage
4. See all saved data
5. Edit/delete values
```

---

## 🆘 Advanced Troubleshooting

### If Nothing Works

**Step 1: Reset Everything**
```
1. Delete script.js
2. Refresh page in browser
3. Clear browser storage: Press F12 → App → Clear Site Data
4. Re-create script.js with fresh code
```

**Step 2: Validate HTML**
```
1. Copy index.html content
2. Go to validator.w3.org
3. Paste and validate
4. Fix any errors
```

**Step 3: Validate CSS**
```
1. Copy styles.css content
2. Go to jigsaw.w3.org/css
3. Paste and validate
4. Fix any syntax errors
```

**Step 4: Test in Different Browser**
```
Try in:
- Chrome
- Firefox
- Edge
- Safari

If works in one browser but not another,
it's a browser compatibility issue.
```

### Browser Compatibility

```javascript
// Check what features browser supports:
const features = {
    'IntersectionObserver': typeof IntersectionObserver,
    'localStorage': typeof Storage,
    'fetch': typeof fetch,
    'Promise': typeof Promise,
    'Promise.all': typeof Promise.all
};
console.table(features);
```

---

## 📞 Getting Help

### Check These Resources:
1. [ACTIVITY_4_JAVASCRIPT_REPORT.md](ACTIVITY_4_JAVASCRIPT_REPORT.md) - Feature explanations
2. [JAVASCRIPT_TESTING_GUIDE.md](JAVASCRIPT_TESTING_GUIDE.md) - Test all features
3. [Script.js comments](script.js) - Read code comments
4. JavaScript console errors - Read carefully

### Search for Solutions:
- Google: "[problem] javascript"
- Stack Overflow: site:stackoverflow.com [problem]
- MDN Web Docs: site:developer.mozilla.org [topic]

### Common Error Messages:

| Error | Meaning | Fix |
|-------|---------|-----|
| `Cannot read property 'X' of null` | Element not found | Check HTML selector |
| `is not a function` | Called non-function as function | Check function exists |
| `Unexpected token` | Syntax error | Check code punctuation |
| `CORS error` | Cross-origin request blocked | Use correct file paths |

---

## ✅ Verification Checklist

**Before declaring done:**

- [ ] Open DevTools Console
- [ ] Refresh page
- [ ] Check for any red error messages
- [ ] Click each feature (menu, filters, lightbox, form)
- [ ] Test all form validations
- [ ] Test on mobile size (< 768px)
- [ ] Test in 2 different browsers
- [ ] Press F5 refresh multiple times
- [ ] Check localStorage preserved
- [ ] Read through script.js to understand code

---

## 🎯 Quick Debugging Map

```
Feature Not Working?
│
├─ Check console errors (F12) → YES? Fix error
├─ Check browser size (mobile vs desktop) → Wrong size? Resize
├─ Check file paths (script.js location) → Wrong path? Fix
├─ Check HTML element exists (Inspect) → Not found? Create it
├─ Check CSS loaded (look for styles) → Missing? Add CSS
├─ Check JavaScript running (console.log) → No log? Script not loading
├─ Check browser supports feature → Too old? Use different browser
└─ Nothing worked? Reset and start fresh
```

---

## 📚 Related Documentation

- [ACTIVITY_4_JAVASCRIPT_REPORT.md](ACTIVITY_4_JAVASCRIPT_REPORT.md) - Feature details
- [JAVASCRIPT_TESTING_GUIDE.md](JAVASCRIPT_TESTING_GUIDE.md) - All tests
- [script.js](script.js) - Source code with comments
- [README.md](README.md) - Project overview

---

**Debugging Guide Complete** ✅

**Most issues are solved by checking console first!**

---
