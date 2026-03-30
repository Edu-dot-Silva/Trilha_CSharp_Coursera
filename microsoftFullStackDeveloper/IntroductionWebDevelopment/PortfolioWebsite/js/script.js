/**
 * Portfolio Website - JavaScript
 * Atividade 4: Interactive Features with JavaScript
 * 
 * Features:
 * - Hamburger menu toggle
 * - Smooth scrolling
 * - Project filtering
 * - Lightbox for images
 * - Form validation
 * - Dark mode toggle
 */

// ========================================
// 1. HAMBURGER MENU & MOBILE NAVIGATION
// ========================================

/**
 * Initialize hamburger menu
 * Creates hamburger button for mobile navigation
 */
function initHamburgerMenu() {
    // Check if hamburger already exists
    if (document.querySelector('.hamburger')) {
        return; // Already initialized
    }

    // Create hamburger button
    const hamburger = document.createElement('div');
    hamburger.className = 'hamburger';
    hamburger.innerHTML = `
        <span></span>
        <span></span>
        <span></span>
    `;
    hamburger.setAttribute('aria-label', 'Toggle navigation menu');
    hamburger.setAttribute('role', 'button');
    hamburger.setAttribute('tabindex', '0');

    // Insert hamburger into nav container
    const navContainer = document.querySelector('.nav-container');
    if (navContainer) {
        navContainer.insertBefore(hamburger, document.querySelector('.nav-links'));
    }

    // Add click event
    hamburger.addEventListener('click', toggleMenu);

    // Add keyboard support
    hamburger.addEventListener('keypress', (e) => {
        if (e.key === 'Enter' || e.key === ' ') {
            e.preventDefault();
            toggleMenu();
        }
    });
}

/**
 * Toggle mobile menu visibility
 */
function toggleMenu() {
    const hamburger = document.querySelector('.hamburger');
    const navLinks = document.querySelector('.nav-links');

    if (hamburger && navLinks) {
        hamburger.classList.toggle('active');
        navLinks.classList.toggle('active');

        // Update ARIA attributes for accessibility
        const isActive = hamburger.classList.contains('active');
        hamburger.setAttribute('aria-expanded', isActive);
        navLinks.setAttribute('aria-hidden', !isActive);
    }
}

/**
 * Close menu when link is clicked
 */
function setupNavLinkClickHandlers() {
    const navLinks = document.querySelectorAll('.nav-links a');
    
    navLinks.forEach((link) => {
        link.addEventListener('click', () => {
            const hamburger = document.querySelector('.hamburger');
            const navLinksContainer = document.querySelector('.nav-links');

            // Close menu
            if (hamburger && navLinksContainer) {
                hamburger.classList.remove('active');
                navLinksContainer.classList.remove('active');
                hamburger.setAttribute('aria-expanded', 'false');
                navLinksContainer.setAttribute('aria-hidden', 'true');
            }
        });
    });
}


// ========================================
// 2. SMOOTH SCROLLING
// ========================================

/**
 * Enable smooth scrolling for anchor links
 */
function enableSmoothScrolling() {
    // This is actually handled by CSS: scroll-behavior: smooth;
    // But we can enhance it with JavaScript if needed

    document.querySelectorAll('a[href^="#"]').forEach((anchor) => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            
            const targetId = this.getAttribute('href').substring(1);
            const targetElement = document.getElementById(targetId);

            if (targetElement) {
                targetElement.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });

                // Set focus to target for accessibility
                targetElement.focus();

                // Add visual indicator
                targetElement.style.boxShadow = 'inset 0 0 0 3px rgba(37, 99, 235, 0.3)';
                setTimeout(() => {
                    targetElement.style.boxShadow = '';
                }, 500);
            }
        });
    });
}


// ========================================
// 3. PROJECT FILTERING
// ========================================

/**
 * Initialize project filtering
 */
function initProjectFiltering() {
    // Add filter buttons
    const projectsSection = document.getElementById('projects');
    
    if (!projectsSection) return;

    // Create filter container
    const filterContainer = document.createElement('div');
    filterContainer.className = 'filter-container';
    filterContainer.innerHTML = `
        <button class="filter-btn active" data-filter="all">All Projects</button>
        <button class="filter-btn" data-filter="frontend">Frontend</button>
        <button class="filter-btn" data-filter="backend">Backend</button>
        <button class="filter-btn" data-filter="fullstack">Full Stack</button>
    `;

    // Insert filter buttons
    const heading = projectsSection.querySelector('h2');
    if (heading) {
        heading.parentNode.insertBefore(filterContainer, heading.nextSibling);
    }

    // Add filter button click handlers
    document.querySelectorAll('.filter-btn').forEach((button) => {
        button.addEventListener('click', () => {
            const filter = button.getAttribute('data-filter');
            filterProjects(filter);

            // Update active button
            document.querySelectorAll('.filter-btn').forEach((btn) => {
                btn.classList.remove('active');
            });
            button.classList.add('active');
        });
    });
}

/**
 * Filter projects by category
 * @param {string} category - The category to filter by ("all", "frontend", "backend", "fullstack")
 */
function filterProjects(category) {
    const projectCards = document.querySelectorAll('.project-card');

    projectCards.forEach((card) => {
        // Get category from card (stored in data attribute)
        const cardCategory = card.getAttribute('data-category') || 'fullstack';

        // Show/hide based on filter
        if (category === 'all' || cardCategory === category) {
            card.style.display = 'block';
            // Add animation
            card.style.animation = 'fadeInUp 0.5s ease-out';
        } else {
            card.style.display = 'none';
        }
    });

    console.log(`Projects filtered by: ${category}`);
}

/**
 * Add categories to project cards (set data attributes)
 */
function categorizeProjects() {
    const projectCards = document.querySelectorAll('.project-card');

    // Assign categories (in real scenario, these would be in the HTML)
    const categories = ['fullstack', 'fullstack', 'backend'];
    
    projectCards.forEach((card, index) => {
        card.setAttribute('data-category', categories[index] || 'fullstack');
    });
}


// ========================================
// 4. LIGHTBOX FOR IMAGES
// ========================================

/**
 * Initialize lightbox for project images
 */
function initLightbox() {
    // Create lightbox HTML
    const lightbox = document.createElement('div');
    lightbox.id = 'lightbox';
    lightbox.className = 'lightbox';
    lightbox.innerHTML = `
        <div class="lightbox-content">
            <button class="lightbox-close" aria-label="Close lightbox">×</button>
            <img id="lightbox-image" src="" alt="Project image" />
            <div class="lightbox-caption"></div>
        </div>
    `;
    document.body.appendChild(lightbox);

    // Add click handlers to project images
    document.querySelectorAll('.project-image').forEach((image) => {
        image.style.cursor = 'pointer';
        image.addEventListener('click', () => {
            openLightbox(image.src, image.alt);
        });
    });

    // Close lightbox button
    document.querySelector('.lightbox-close').addEventListener('click', closeLightbox);

    // Close on background click
    lightbox.addEventListener('click', (e) => {
        if (e.target === lightbox) {
            closeLightbox();
        }
    });

    // Keyboard support
    document.addEventListener('keydown', (e) => {
        if (e.key === 'Escape') {
            closeLightbox();
        }
    });
}

/**
 * Open lightbox with image
 * @param {string} imageSrc - Source of the image
 * @param {string} imageAlt - Alt text of the image
 */
function openLightbox(imageSrc, imageAlt) {
    const lightbox = document.getElementById('lightbox');
    const lightboxImage = document.getElementById('lightbox-image');
    const caption = document.querySelector('.lightbox-caption');

    lightboxImage.src = imageSrc;
    lightboxImage.alt = imageAlt;
    caption.textContent = imageAlt;

    lightbox.classList.add('active');
    document.body.style.overflow = 'hidden'; // Prevent background scrolling

    console.log(`Lightbox opened: ${imageAlt}`);
}

/**
 * Close lightbox
 */
function closeLightbox() {
    const lightbox = document.getElementById('lightbox');
    lightbox.classList.remove('active');
    document.body.style.overflow = ''; // Restore scrolling

    console.log('Lightbox closed');
}


// ========================================
// 5. FORM VALIDATION
// ========================================

/**
 * Initialize form validation
 */
function initFormValidation() {
    const contactForm = document.querySelector('.contact-form');

    if (!contactForm) return;

    // Form submission handler
    contactForm.addEventListener('submit', (e) => {
        e.preventDefault();

        // Validate form
        if (validateForm(contactForm)) {
            submitForm(contactForm);
        } else {
            console.log('Form validation failed');
        }
    });

    // Real-time validation on input
    const formInputs = contactForm.querySelectorAll('input, textarea');
    formInputs.forEach((input) => {
        input.addEventListener('blur', () => {
            validateField(input);
        });

        input.addEventListener('input', () => {
            // Clear error on input
            if (input.classList.contains('error')) {
                input.classList.remove('error');
                const errorMsg = input.parentNode.querySelector('.error-message');
                if (errorMsg) {
                    errorMsg.remove();
                }
            }
        });
    });
}

/**
 * Validate entire form
 * @param {HTMLElement} form - The form element
 * @returns {boolean} - True if form is valid
 */
function validateForm(form) {
    let isValid = true;
    const fields = form.querySelectorAll('input, textarea');

    fields.forEach((field) => {
        if (!validateField(field)) {
            isValid = false;
        }
    });

    return isValid;
}

/**
 * Validate individual field
 * @param {HTMLElement} field - The input/textarea field
 * @returns {boolean} - True if field is valid
 */
function validateField(field) {
    const value = field.value.trim();
    const fieldType = field.type || field.tagName.toLowerCase();
    let isValid = true;
    let errorMessage = '';

    // Check if field is required and empty
    if (!value) {
        isValid = false;
        errorMessage = `${field.name || 'This field'} is required`;
    }
    // Email validation
    else if (fieldType === 'email') {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(value)) {
            isValid = false;
            errorMessage = 'Please enter a valid email address';
        }
    }
    // Name validation (minimum 2 characters)
    else if (field.id === 'name' && value.length < 2) {
        isValid = false;
        errorMessage = 'Name must be at least 2 characters';
    }
    // Message validation (minimum 10 characters)
    else if (field.id === 'message' && value.length < 10) {
        isValid = false;
        errorMessage = 'Message must be at least 10 characters';
    }

    // Display error message
    if (!isValid) {
        field.classList.add('error');
        const existingError = field.parentNode.querySelector('.error-message');
        if (existingError) existingError.remove();

        const errorMsg = document.createElement('small');
        errorMsg.className = 'error-message';
        errorMsg.textContent = errorMessage;
        field.parentNode.appendChild(errorMsg);

        console.warn(`Validation error in ${field.name}: ${errorMessage}`);
    } else {
        field.classList.remove('error');
        const errorMsg = field.parentNode.querySelector('.error-message');
        if (errorMsg) errorMsg.remove();
    }

    return isValid;
}

/**
 * Submit form
 * @param {HTMLElement} form - The form element
 */
function submitForm(form) {
    // Show success message
    showSuccessMessage('Thank you! Your message has been sent successfully.');

    // Reset form
    form.reset();

    // Clear any error classes
    form.querySelectorAll('.error').forEach((field) => {
        field.classList.remove('error');
    });

    console.log('Form submitted successfully');

    // Optional: Send to server
    // sendFormData(new FormData(form));
}

/**
 * Show success message
 * @param {string} message - Message to display
 */
function showSuccessMessage(message) {
    const contactForm = document.querySelector('.contact-form');

    if (!contactForm) return;

    // Remove existing messages
    const existingMsg = document.querySelector('.success-message');
    if (existingMsg) existingMsg.remove();

    // Create success message
    const successMsg = document.createElement('div');
    successMsg.className = 'success-message';
    successMsg.setAttribute('role', 'alert');
    successMsg.textContent = message;

    // Insert before form
    contactForm.parentNode.insertBefore(successMsg, contactForm);

    // Remove after 5 seconds
    setTimeout(() => {
        successMsg.style.animation = 'fadeOut 0.5s ease-out';
        setTimeout(() => {
            successMsg.remove();
        }, 500);
    }, 5000);
}


// ========================================
// 6. DARK MODE TOGGLE (BONUS)
// ========================================

/**
 * Initialize dark mode toggle
 */
function initDarkModeToggle() {
    // Check if user has dark mode preference
    const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
    const savedMode = localStorage.getItem('darkMode');

    // Apply saved mode or preference
    if (savedMode === 'true' || (savedMode === null && prefersDark)) {
        enableDarkMode();
    }
}

/**
 * Enable dark mode
 */
function enableDarkMode() {
    document.documentElement.style.colorScheme = 'dark';
    localStorage.setItem('darkMode', 'true');
    console.log('Dark mode enabled');
}

/**
 * Disable dark mode
 */
function disableDarkMode() {
    document.documentElement.style.colorScheme = 'light';
    localStorage.setItem('darkMode', 'false');
    console.log('Dark mode disabled');
}


// ========================================
// 7. SCROLL ANIMATIONS (BONUS)
// ========================================

/**
 * Initialize scroll animations - fade in sections as they come into view
 */
function initScrollAnimations() {
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach((entry) => {
            if (entry.isIntersecting) {
                entry.target.style.animation = 'fadeInUp 0.6s ease-out forwards';
                observer.unobserve(entry.target);
            }
        });
    }, observerOptions);

    // Observe all sections
    document.querySelectorAll('section').forEach((section) => {
        section.style.opacity = '0';
        observer.observe(section);
    });
}

/**
 * Observe active section in navigation
 */
function initActiveNavTracking() {
    const sections = document.querySelectorAll('section');
    const navLinks = document.querySelectorAll('.nav-links a');

    const observer = new IntersectionObserver((entries) => {
        entries.forEach((entry) => {
            if (entry.isIntersecting) {
                const id = entry.target.id;
                navLinks.forEach((link) => {
                    link.classList.remove('active');
                    if (link.getAttribute('href') === `#${id}`) {
                        link.classList.add('active');
                    }
                });
            }
        });
    }, { threshold: 0.5 });

    sections.forEach((section) => {
        observer.observe(section);
    });
}


// ========================================
// 8. INITIALIZATION
// ========================================

/**
 * Initialize all features when DOM is loaded
 */
function initializeAll() {
    console.log('Initializing Portfolio Website JavaScript...');

    // Core features
    initHamburgerMenu();
    setupNavLinkClickHandlers();
    enableSmoothScrolling();
    initProjectFiltering();
    categorizeProjects();
    initLightbox();
    initFormValidation();

    // Bonus features
    initDarkModeToggle();
    initScrollAnimations();
    initActiveNavTracking();

    console.log('Initialization complete!');
}

// Run initialization when DOM is ready
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', initializeAll);
} else {
    // DOM is already loaded
    initializeAll();
}


// ========================================
// 9. UTILITY FUNCTIONS
// ========================================

/**
 * Log messages for debugging (disable in production)
 */
const DEBUG = true; // Set to false in production

function log(message, data = null) {
    if (DEBUG) {
        if (data) {
            console.log(`[Portfolio] ${message}`, data);
        } else {
            console.log(`[Portfolio] ${message}`);
        }
    }
}

/**
 * Error handling
 */
window.addEventListener('error', (event) => {
    console.error('JavaScript Error:', event.error);
    console.error('Stack:', event.error.stack);
    // In production, send error to logging service
});

/**
 * Unhandled promise rejection
 */
window.addEventListener('unhandledrejection', (event) => {
    console.error('Unhandled Promise Rejection:', event.reason);
    // In production, send error to logging service
});
