import { Link } from "react-router-dom";
import "../Styles/Footer.css";

const DEFAULT_SECTIONS = [
  {
    title: "Upptäck",
    links: [
      { label: "Alla Aktiviteter", href: "/" },
      { label: "Kategorier", href: "/about" },
      { label: "Populära Aktiviteter", href: "/about" },
    ],
  },
  {
    title: "Om Oss",
    links: [{ label: "Vårt Team", href: "/about" }],
  },
  {
    title: "Support",
    links: [
      { label: "Hjälpcenter", href: "/contact" },
      { label: "Kontakta Oss", href: "/contact" },
      { label: "Villkor", href: "/contact" },
    ],
  },
];

export default function Footer({
  brand = {
    name: "ActiviGo",
    tagline: "Din plattform för att upptäcka och boka spännande aktiviteter!",
  },
  sections = DEFAULT_SECTIONS,
  meta = {
    year: new Date().getFullYear(),
    company: "ActiviGo AB",
    legal: "Alla rättigheter förbehållna.",
  },
}) {
  return (
    <footer className="footer">
      <div className="footer-main">
        <div className="footer-brand">
          <h3 className="footer-brand-name">{brand.name}</h3>
          {brand.tagline && (
            <p className="footer-brand-tagline">{brand.tagline}</p>
          )}
        </div>

        {/* Länkkolumner */}
        {sections.map((section) => (
          <nav
            key={section.title}
            aria-labelledby={`footer-${slug(section.title)}`}
          >
            <h4
              id={`footer-${slug(section.title)}`}
              className="footer-section-title"
            >
              {section.title}
            </h4>
            <ul className="footer-links">
              {section.links.map((link) => (
                <li key={link.label + link.href}>
                  {link.href?.startsWith("http") ? (
                    <a
                      className="footer-link"
                      href={link.href}
                      target="_blank"
                      rel="noreferrer"
                    >
                      {link.label}
                    </a>
                  ) : (
                    <Link className="footer-link" to={link.href || "#"}>
                      {link.label}
                    </Link>
                  )}
                </li>
              ))}
            </ul>
          </nav>
        ))}
      </div>

      {/* Copyright-rad */}
      <div className="footer-meta">
        <p>
          © {meta.year} {meta.company}. {meta.legal}
        </p>
      </div>
    </footer>
  );
}

function slug(s) {
  return String(s)
    .toLowerCase()
    .normalize("NFD")
    .replace(/\p{Diacritic}/gu, "")
    .replace(/[^a-z0-9]+/g, "-")
    .replace(/(^-|-$)+/g, "");
}
