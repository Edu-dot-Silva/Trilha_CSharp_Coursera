# Implementation Guide - Portfolio Website

## Getting Started

### Step 1: Basic Setup
1. Open the `PortfolioWebsite` folder in VS Code
2. Install a live server extension (e.g., "Live Server" by Ritwick Dey)
3. Right-click on `index.html` → "Open with Live Server"
4. The site will open at `http://localhost:5500/index.html`

### Step 2: Customize Your Information

#### Update Contact Details
In `index.html`, find and replace:
- `your.email@example.com` - Enter your email address
- `yourusername` - Your GitHub username
- `Eduardo` - Your actual name
- `2026` - Current year

#### Add Project Images
1. Create an `images/` directory in the PortfolioWebsite folder
2. Add three project thumbnail images:
   - `project-1-thumbnail.png` (E-Commerce Platform)
   - `project-2-thumbnail.png` (Task Management App)
   - `project-3-thumbnail.png` (Weather Dashboard)
3. Images should be 300x200px for best results
4. Use PNG or JPG format (compressed)

#### Update Project Descriptions
Edit the three `<article class="project-card">` sections with:
- Real project titles
- Accurate descriptions of what you built
- Technologies actually used
- Links to live projects or GitHub repos

#### Customize Content
1. **About Me Section**: Replace the template text with your actual background, experience, and goals
2. **Skills List**: Update with technologies you actually know
3. **Social Links**: Add your real GitHub, LinkedIn, and email

### Step 3: Style Customization

#### Change Color Scheme
Edit the CSS variables at the top of `styles.css`:

```css
:root {
    --primary-color: #2563eb;        /* Main brand color */
    --primary-dark: #1e40af;         /* Darker version for hover */
    --secondary-color: #64748b;      /* Secondary color */
    --text-dark: #1e293b;            /* Dark text */
    --text-light: #64748b;           /* Light text */
    /* ... update others as needed */
}
```

#### Popular Color Combinations:
- **Blue-based** (current): `#2563eb` → `#1e40af`
- **Purple**: `#9333ea` → `#7e22ce`
- **Green**: `#10b981` → `#059669`
- **Orange**: `#F97316` → `#EA580C`
- **Indigo**: `#4f46e5` → `#4338ca`

#### Change Fonts
In `styles.css`, update the font-family:

```css
--font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
```

Popular alternatives:
- `'Arial', sans-serif` - Reliable system font
- `'Georgia', serif` - Professional serif
- `'Courier New', monospace` - Code-like
- With imports: `@import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;700&display=swap');`

### Step 4: Add More Content (Optional)

#### Add More Projects
Copy one of the project cards and paste it after the existing ones:

```html
<article class="project-card">
    <figure>
        <img 
            src="images/project-X-thumbnail.png" 
            alt="Description of your project"
            class="project-image"
        >
        <figcaption>Project Name</figcaption>
    </figure>
    <h3>Project Name</h3>
    <p>Description of the project and technologies used.</p>
    <ul>
        <li>Technology 1</li>
        <li>Technology 2</li>
        <li>Technology 3</li>
    </ul>
    <a href="project-link.html" class="btn btn-primary" tabindex="0">View Project</a>
</article>
```

#### Add More Skills
To add skills in a new category, add another skill-category div:

```html
<div class="skill-category">
    <h3>Your Category</h3>
    <ul class="skills-list">
        <li>Skill 1</li>
        <li>Skill 2</li>
        <li>Skill 3</li>
    </ul>
</div>
```

### Step 5: Make Form Functional

Currently, the form shows a basic alert. To make it functional:

#### Option 1: Email Service (Easiest)
Use a service like Formspree:

```html
<form class="contact-form" action="https://formspree.io/f/YOUR_FORM_ID" method="POST">
```

1. Go to https://formspree.io
2. Sign up free
3. Create a new form
4. Replace the action URL

#### Option 2: Backend Processing
Create a `handler.php` or Node.js endpoint:

```html
<form class="contact-form" action="/api/contact" method="POST">
```

Then handle the submission on your server.

#### Option 3: Continue with Alert
The current setup shows an alert but doesn't send anything. This is fine for the activity.

---

## File Descriptions

### index.html
The main HTML file containing:
- Semantic HTML structure with proper tags
- ARIA attributes for accessibility
- Contact form with all required fields
- Navigation and footer
- All sections structured with proper heading hierarchy

**Key Sections:**
- Header with navigation (lines 12-24)
- About Me (lines 37-52)
- Projects (lines 55-120)
- Skills (lines 123-170)
- Contact Form (lines 173-225)
- Footer (lines 228-244)

### styles.css
Complete CSS stylesheet featuring:
- CSS variables for easy theming
- Mobile-first responsive design
- Accessibility-focused styling
- Print styles
- Dark mode preferences support

**Key Features:**
- Grid and Flexbox layouts
- Media queries for responsive design
- Focus and hover states
- Color contrast compliance
- Smooth transitions and animations

### ACCESSIBILITY_CHECKLIST.md
Detailed checklist documenting:
- WCAG 2.1 Level AA compliance
- SEO best practices
- Responsive design implementation
- Code quality standards
- Testing recommendations

### README.md
Project documentation including:
- Feature overview
- Structure and organization
- Customization guide
- Enhancement ideas
- Browser compatibility

---

## Best Practices Used

### Semantic HTML
Using meaningful HTML tags (`<header>`, `<nav>`, `<main>`, `<section>`, `<article>`) helps both:
- Search engines understand page structure
- Screen readers navigate more effectively

### ARIA Labels
ARIA (Accessible Rich Internet Applications) attributes:
- `aria-label` - Describes elements without visible text
- `aria-labelledby` - Links sections to their headings
- `aria-required` - Indicates required form fields
- `role` - Defines element purpose to assistive tech

### Keyboard Navigation
Every interactive element must be:
- Reachable with Tab key
- Activatable with Enter/Space
- Clearly focused with visible outline

### Color Contrast
Text must have enough contrast to be readable:
- Normal text: 4.5:1 ratio (WCAG AA)
- Large text (18pt+): 3:1 ratio
- Buttons/links: Same as text

### Responsive Design
Site works on all screen sizes:
- Mobile phones (320px+)
- Tablets (768px+)
- Desktops (1200px+)

### SEO Elements
Help search engines understand your content:
- Meaningful page title and meta description
- Proper heading structure
- Descriptive link text
- Image alt attributes

---

## Accessibility Testing

### Quick Manual Tests

1. **Keyboard Only**
   - Navigate using only Tab and Enter keys
   - Verify you can reach all links and buttons
   - Check that focus is always visible

2. **Zoom Test**
   - Zoom to 200% (Ctrl/Cmd + +)
   - Verify text is readable
   - Check that layout doesn't break

3. **Color Only**
   - Disable colors (use DevTools filters)
   - Verify content is still understandable
   - Check that links are identified by more than color

4. **Text Size**
   - Increase text size in browser settings
   - Verify layout adapts gracefully

### Browser Tools

1. **axe DevTools** (Chrome/Firefox extension)
   - Automated accessibility checks
   - Reports violations and passes

2. **WAVE** (WebAIM.org)
   - Identifies accessibility issues
   - Provides suggestions

3. **Lighthouse** (Chrome DevTools)
   - Accessibility audit
   - Performance and SEO checks

---

## Common Customization Tasks

### Change Primary Color
Find this line in `styles.css`:
```css
--primary-color: #2563eb;
```
Change `#2563eb` to your preferred color code.

### Adjust Font Size
In `styles.css`, modify:
```css
--font-size-base: 16px;
```
Common sizes: 14px (small), 16px (default), 18px (large)

### Change Navigation Style
Edit the nav section in `styles.css` around line 120:
```css
.nav-links {
    display: flex;
    list-style: none;
    gap: 2rem;
}
```
Adjust `gap` value to change spacing between nav items.

### Modify Section Spacing
In `styles.css`, adjust:
```css
section {
    margin: 3rem 0;      /* Space above/below */
    padding: 2rem 0;     /* Space inside section */
}
```

---

## Next Steps for Future Activities

### Activity 2: Add CSS Styling
- Enhance the current CSS
- Add animations and transitions
- Implement more complex layouts

### Activity 3: Add JavaScript Interactivity
- Form validation
- Dark mode toggle
- Smooth scroll animations
- Filter projects by technology

### Activity 4: Deploy to Web
- Use services like GitHub Pages, Netlify, or Vercel
- Set up custom domain (optional)
- Configure form submission backend

### Activity 5: Optimization
- Minimize CSS and HTML
- Optimize images
- Add service workers
- Implement lazy loading

---

## Resources & Tools

### Learning Resources
- [MDN Web Docs](https://developer.mozilla.org/)
- [Web.dev Best Practices](https://web.dev/)
- [WCAG Guidelines](https://www.w3.org/WAI/WCAG21/quickref/)

### Online Tools
- [Color Contrast Checker](https://webaim.org/resources/contrastchecker/)
- [HTML Validator](https://validator.w3.org/)
- [CSS Validator](https://jigsaw.w3.org/css-validator/)
- [Lighthouse Audit](https://developers.google.com/web/tools/lighthouse)

### Extensions
- axe DevTools (Chrome/Firefox)
- Wave (Chrome/Firefox)
- Lighthouse (Chrome DevTools)
- Color Contrast Analyzer

---

## Tips for Success

1. **Validate Your Code**
   - Use W3C Validator for HTML
   - Check CSS for errors
   - Use browser console to catch JavaScript errors

2. **Test Accessibility**
   - Use keyboard navigation
   - Test with screen reader
   - Check zoom and text sizing
   - Verify color contrast

3. **Monitor Performance**
   - Use Lighthouse audit
   - Check page load time
   - Minimize large files
   - Optimize images

4. **Stay Updated**
   - Follow web standards
   - Learn new best practices
   - Use modern CSS features
   - Keep browser support in mind

5. **Document Your Work**
   - Add comments to complex code
   - Keep README up to date
   - Version your changes
   - Note any customizations

---

**Version**: 1.0  
**Last Updated**: March 2026  
**For Questions**: Refer to README.md and ACCESSIBILITY_CHECKLIST.md
