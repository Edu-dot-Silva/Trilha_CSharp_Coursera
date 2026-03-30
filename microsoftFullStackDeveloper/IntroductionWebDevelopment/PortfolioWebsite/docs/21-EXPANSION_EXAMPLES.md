<!-- Example: Additional Project Categories for Future Expansion -->
<!-- This file shows how to extend the portfolio with different project types and categories -->

<!-- EXAMPLE 1: Add a Blog Section to the Portfolio -->
<section id="blog" aria-labelledby="blog-heading">
    <h2 id="blog-heading">Latest Blog Posts</h2>
    <div class="blog-container">
        <article class="blog-card">
            <h3>Understanding Semantic HTML</h3>
            <div class="blog-metadata">
                <time datetime="2026-03-15">March 15, 2026</time>
                <span class="read-time">5 min read</span>
            </div>
            <p>Learn why semantic HTML elements are crucial for accessibility and SEO. 
               In this post, we explore the importance of using elements like &lt;header&gt;, 
               &lt;nav&gt;, &lt;main&gt;, and &lt;article&gt;.</p>
            <a href="blog/semantic-html.html" class="btn btn-primary" tabindex="0">Read Article</a>
        </article>

        <article class="blog-card">
            <h3>Web Accessibility Best Practices</h3>
            <div class="blog-metadata">
                <time datetime="2026-03-10">March 10, 2026</time>
                <span class="read-time">8 min read</span>
            </div>
            <p>Discover the key principles of making your website accessible to everyone. 
               From keyboard navigation to ARIA labels, learn how to create inclusive web 
               experiences.</p>
            <a href="blog/accessibility-best-practices.html" class="btn btn-primary" tabindex="0">Read Article</a>
        </article>
    </div>
</section>

<!-- EXAMPLE 2: Add a Testimonials/Reviews Section -->
<section id="testimonials" aria-labelledby="testimonials-heading">
    <h2 id="testimonials-heading">What Others Say</h2>
    <div class="testimonials-container">
        <blockquote class="testimonial">
            <p>"Eduardo's attention to detail and understanding of accessibility standards 
               makes their work stand out. They deliver not just functional code, but 
               inclusive experiences."</p>
            <footer>
                <strong>Sarah Johnson</strong>
                <em>Project Manager, Tech Company</em>
            </footer>
        </blockquote>

        <blockquote class="testimonial">
            <p>"Working with Eduardo on our redesign was seamless. They asked the right 
               questions, provided excellent solutions, and delivered on time with clean, 
               well-documented code."</p>
            <footer>
                <strong>Michael Chen</strong>
                <em>CEO, Digital Agency</em>
            </footer>
        </blockquote>
    </div>
</section>

<!-- EXAMPLE 3: Enhanced Project Card with More Details -->
<article class="project-card project-card-detailed" role="article">
    <div class="project-status">
        <span class="badge badge-featured">Featured</span>
        <span class="badge badge-award">Award Winner</span>
    </div>
    
    <figure>
        <img 
            src="images/advanced-project.png" 
            alt="Screenshot of advanced e-learning platform showing course dashboard with progress tracking"
            class="project-image"
        >
        <figcaption>E-Learning Platform</figcaption>
    </figure>

    <div class="project-content">
        <h3>Advanced E-Learning Platform</h3>
        
        <p class="project-description">
            A comprehensive e-learning solution with course management, 
            student progress tracking, and interactive assessments.
        </p>

        <div class="project-stats">
            <div class="stat">
                <strong>1000+</strong>
                <p>Active Users</p>
            </div>
            <div class="stat">
                <strong>50+</strong>
                <p>Courses</p>
            </div>
            <div class="stat">
                <strong>4.8★</strong>
                <p>Rating</p>
            </div>
        </div>

        <div class="project-technologies">
            <h4>Technologies Used:</h4>
            <ul class="tech-list">
                <li class="tech-tag">HTML5</li>
                <li class="tech-tag">CSS3</li>
                <li class="tech-tag">JavaScript</li>
                <li class="tech-tag">React</li>
                <li class="tech-tag">Node.js</li>
                <li class="tech-tag">MongoDB</li>
            </ul>
        </div>

        <div class="project-links">
            <a href="https://example.com/project" class="btn btn-primary" tabindex="0">View Live</a>
            <a href="https://github.com/username/project" class="btn btn-secondary" tabindex="0">View Code</a>
        </div>
    </div>
</article>

<!-- EXAMPLE 4: Timeline Section for Experience/Timeline -->
<section id="experience" aria-labelledby="experience-heading">
    <h2 id="experience-heading">Professional Timeline</h2>
    <div class="timeline">
        <div class="timeline-item">
            <div class="timeline-marker"></div>
            <div class="timeline-content">
                <h3>Senior Frontend Developer</h3>
                <p class="timeline-date">2024 - Present</p>
                <p>Leading frontend development team at TechCorp, implementing 
                   accessibility standards and performance optimization.</p>
            </div>
        </div>

        <div class="timeline-item">
            <div class="timeline-marker"></div>
            <div class="timeline-content">
                <h3>Full Stack Developer</h3>
                <p class="timeline-date">2022 - 2024</p>
                <p>Built and maintained several React applications with Node.js 
                   backends for StartupX.</p>
            </div>
        </div>

        <div class="timeline-item">
            <div class="timeline-marker"></div>
            <div class="timeline-content">
                <h3>Junior Web Developer</h3>
                <p class="timeline-date">2020 - 2022</p>
                <p>Started career building static websites and learning modern 
                   web development practices.</p>
            </div>
        </div>
    </div>
</section>

<!-- EXAMPLE 5: Statistics/Metrics Section -->
<section id="stats" class="stats-section" aria-label="Portfolio Statistics">
    <div class="stats-grid">
        <div class="stat-card">
            <div class="stat-number">25+</div>
            <p>Projects Completed</p>
        </div>
        <div class="stat-card">
            <div class="stat-number">50+</div>
            <p>Happy Clients</p>
        </div>
        <div class="stat-card">
            <div class="stat-number">5+</div>
            <p>Years Experience</p>
        </div>
        <div class="stat-card">
            <div class="stat-number">100%</div>
            <p>Accessibility Compliant</p>
        </div>
    </div>
</section>

<!-- EXAMPLE 6: Call-to-Action Section -->
<section id="cta" class="cta-section" aria-label="Call to action">
    <div class="cta-content">
        <h2>Ready to Start Your Next Project?</h2>
        <p>Let's create something amazing together. I'm available for freelance work 
           and full-time opportunities.</p>
        <a href="#contact" class="btn btn-primary btn-large" tabindex="0">Get In Touch</a>
    </div>
</section>

<!-- EXAMPLE 7: Services/Expertise Section -->
<section id="services" aria-labelledby="services-heading">
    <h2 id="services-heading">Services I Offer</h2>
    <div class="services-grid">
        <div class="service-card">
            <div class="service-icon">🎨</div>
            <h3>Web Design</h3>
            <p>Creating beautiful, responsive web designs that work on all devices 
               and follow modern design principles.</p>
        </div>

        <div class="service-card">
            <div class="service-icon">💻</div>
            <h3>Frontend Development</h3>
            <p>Building interactive user interfaces with HTML, CSS, and JavaScript, 
               with a focus on accessibility and performance.</p>
        </div>

        <div class="service-card">
            <div class="service-icon">⚙️</div>
            <h3>Backend Development</h3>
            <p>Developing robust server-side applications using modern frameworks 
               and best practices in C#, .NET, and Node.js.</p>
        </div>

        <div class="service-card">
            <div class="service-icon">🔍</div>
            <h3>SEO Optimization</h3>
            <p>Implementing SEO best practices to ensure your website ranks well 
               in search engines and reaches your target audience.</p>
        </div>

        <div class="service-card">
            <div class="service-icon">♿</div>
            <h3>Accessibility Audit</h3>
            <p>Ensuring your website meets WCAG standards and is accessible to 
               everyone, including people with disabilities.</p>
        </div>

        <div class="service-card">
            <div class="service-icon">🚀</div>
            <h3>Performance Optimization</h3>
            <p>Optimizing websites for speed and efficiency, resulting in better 
               user experience and improved search rankings.</p>
        </div>
    </div>
</section>

<!-- EXAMPLE 8: FAQ Section -->
<section id="faq" aria-labelledby="faq-heading">
    <h2 id="faq-heading">Frequently Asked Questions</h2>
    <div class="faq-list">
        <details class="faq-item">
            <summary class="faq-question">
                What is your typical project timeline?
                <span class="faq-toggle" aria-hidden="true">+</span>
            </summary>
            <div class="faq-answer">
                <p>Most projects take 2-4 weeks depending on complexity. I provide 
                   detailed estimates after an initial consultation.</p>
            </div>
        </details>

        <details class="faq-item">
            <summary class="faq-question">
                Do you offer maintenance and support?
                <span class="faq-toggle" aria-hidden="true">+</span>
            </summary>
            <div class="faq-answer">
                <p>Yes! I offer ongoing support packages including bug fixes, 
                   feature updates, and performance monitoring.</p>
            </div>
        </details>

        <details class="faq-item">
            <summary class="faq-question">
                What technologies do you specialize in?
                <span class="faq-toggle" aria-hidden="true">+</span>
            </summary>
            <div class="faq-answer">
                <p>I specialize in modern web technologies including HTML5, CSS3, 
                   JavaScript, React, Node.js, and C#/.NET.</p>
            </div>
        </details>
    </div>
</section>

<!--
NOTES ON USING THESE EXAMPLES:

1. BLOG SECTION
   - Add date metadata using <time> datetime attribute
   - Use read-time estimates for better UX
   - Link to individual blog post pages

2. TESTIMONIALS
   - Use <blockquote> for semantic structure
   - Include attribution information
   - Consider adding client images in production
   - Use ratings/stars if available

3. ENHANCED PROJECTS
   - Add status badges for featured/award-winning projects
   - Include project statistics and metrics
   - Show technologies used as tags
   - Provide links to live projects and GitHub

4. TIMELINE
   - Use structured data with timeline markers
   - Include dates and descriptions
   - Good for showing experience/history
   - Can be styled as vertical or horizontal

5. STATISTICS
   - Display key metrics about your work
   - Update regularly with real numbers
   - Good for credibility and trust
   - Responsive grid layout

6. CTA SECTION
   - Encourage visitors to take action
   - Use strong, clear calls-to-action
   - Place strategically (e.g., between sections)
   - Link to contact form

7. SERVICES
   - Use icons or emojis for visual interest
   - Keep descriptions concise
   - Organize in a grid layout
   - Focus on benefits, not just features

8. FAQ
   - Use <details> and <summary> for interactive FAQs
   - Keyboard accessible and semantic
   - Can be styled with CSS
   - Great for SEO

CSS NOTES:
- For these examples, you'll need to add CSS classes like:
  .blog-container, .blog-card, .testimonials-container, etc.
- Use similar grid and flexbox patterns as in the main styles.css
- Ensure color contrast and accessibility compliance
- Test keyboard navigation with <details> elements

ACCESSIBILITY:
- Use proper semantic HTML (article, time, details, summary)
- Add aria-labels where helpful
- Ensure keyboard navigation works
- Maintain color contrast ratios
- Include alt text for any icons/images

FUTURE IMPROVEMENT:
- Consider adding search functionality for blog posts
- Add filtering for projects by technology
- Implement pagination for large lists
- Add comments/reactions on blog posts
-->
